using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace WebApiTestToDo.Security
{
    public class AuthenticateHotelUsers : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {

            HttpRequestMessage request = context.Request;
            
            AuthenticationHeaderValue headers = request.Headers.Authorization;

            if (headers == null)
            {
                return;
            }


            if (headers.Scheme != "Basic")
            {
                return;
            }

            if (String.IsNullOrEmpty(headers.Parameter))
            {
                context.ErrorResult = new AuthenticationFailureResult("invalid params", request);
            }



            Tuple<string, string> usepass = ExtractUserNameAndPassword(headers.Parameter);
            if (usepass == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("params not passed", request);
                await context.ErrorResult.ExecuteAsync(cancellationToken);
                return;
            }

            string user = usepass.Item1;
            string pass = usepass.Item2;


            IPrincipal principal = await AuthenticateAsync(user, pass, cancellationToken);
            if (principal == null)
            {
                context.ErrorResult = new AuthenticationFailureResult("Invalid username or password", request);
                await context.ErrorResult.ExecuteAsync(cancellationToken);
                return;
            }

            // 6. If the credentials are valid, set principal.
            else
            {
                context.Principal = principal;
                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
                
            }


            //context.ActionContext.Request.Headers.
            //throw new NotImplementedException();
        }

        private Task<IPrincipal> AuthenticateAsync(string user, string pass, CancellationToken cancellationToken)
        {
            //database query to validate
            if ((user == "jack") && (pass == "roller"))
            {
                //IPrincipal prince = new GenericPrincipal(new GenericIdentity("Andras", "CustomIdentification"), new string[] { "Admin", "PowerUser" });
                IPrincipal prince = new GenericPrincipal(new GenericIdentity(user, "CustomIdentification"), new string[] { "Admin", "PowerUser" });
                
                
                return Task.FromResult(prince);
            }

            return null;
        }

        private Tuple<string, string> ExtractUserNameAndPassword(object parameter)
        {
            string p = (string)parameter;


            if ((parameter==null) ||(String.IsNullOrEmpty(p))) return null;
            byte[] data = Convert.FromBase64String(p);
            p = Encoding.UTF8.GetString(data);
            string[] ps = p.Split(':');
            if (ps.Length<1) return null;


            return Tuple.Create(ps[0], ps[1]);
            // throw new NotImplementedException();
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {

            /* Task.Run(() =>
           {
               IPrincipal incomingPrincipal = context.ActionContext.RequestContext.Principal;
           });*/
            /*
            var challenge = new AuthenticationHeaderValue("Basic");
            context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
            context.ActionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            //context.ActionContext.Response.Headers.WwwAuthenticate.Add(challenge);
            */
            return Task.FromResult(0);
            

        }
    }


    public class AuthenticationFailureResult : IHttpActionResult
    {
        public AuthenticationFailureResult(string reason, HttpRequestMessage message)
        {
            ReasonPhrase = reason;
            Request = message;

        }


        public string ReasonPhrase { get; set; }

        public HttpRequestMessage Request { get; set; }


        public HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.RequestMessage = Request;
            response.ReasonPhrase = ReasonPhrase;
            return response;

        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }
    }





    public class AddChallengeOnUnauthorizedResult : IHttpActionResult
    {
        public AddChallengeOnUnauthorizedResult(AuthenticationHeaderValue challange, IHttpActionResult result)
        {
            Challange = challange;
            InnerResult = result;
        }


        public AuthenticationHeaderValue Challange { get; set; }
        public IHttpActionResult InnerResult { get; set; }


        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage res = await InnerResult.ExecuteAsync(cancellationToken);
            if (res.StatusCode == HttpStatusCode.Unauthorized)
            {
                if (!res.Headers.WwwAuthenticate.Any((h) => h.Scheme == Challange.Scheme))
                {
                    res.Headers.WwwAuthenticate.Add(Challange);
                }
            }
            return res;
        }
    }















    public static class HttpAuthenticationChallengeContextExtensions
    {
        public static void ChallengeWith(this HttpAuthenticationChallengeContext context, string scheme)
        {
            ChallengeWith(context, new AuthenticationHeaderValue(scheme));
        }

        public static void ChallengeWith(this HttpAuthenticationChallengeContext context, string scheme, string parameter)
        {
            ChallengeWith(context, new AuthenticationHeaderValue(scheme, parameter));
        }

        public static void ChallengeWith(this HttpAuthenticationChallengeContext context, AuthenticationHeaderValue challenge)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            context.Result = new AddChallengeOnUnauthorizedResult(challenge, context.Result);
        }
    }










    public abstract class BasicAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public string Realm { get; set; }

        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            HttpRequestMessage request = context.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            if (authorization == null)
            {
                // No authentication was attempted (for this authentication method).
                // Do not set either Principal (which would indicate success) or ErrorResult (indicating an error).
                return;
            }

            if (authorization.Scheme != "Basic")
            {
                // No authentication was attempted (for this authentication method).
                // Do not set either Principal (which would indicate success) or ErrorResult (indicating an error).
                return;
            }

            if (String.IsNullOrEmpty(authorization.Parameter))
            {
                // Authentication was attempted but failed. Set ErrorResult to indicate an error.
                context.ErrorResult = new AuthenticationFailureResult("Missing credentials", request);
                return;
            }

            Tuple<string, string> userNameAndPasword = ExtractUserNameAndPassword(authorization.Parameter);

            if (userNameAndPasword == null)
            {
                // Authentication was attempted but failed. Set ErrorResult to indicate an error.
                context.ErrorResult = new AuthenticationFailureResult("Invalid credentials", request);
                return;
            }

            string userName = userNameAndPasword.Item1;
            string password = userNameAndPasword.Item2;

            IPrincipal principal = await AuthenticateAsync(userName, password, cancellationToken);

            if (principal == null)
            {
                // Authentication was attempted but failed. Set ErrorResult to indicate an error.
                Realm = "Basic";
                context.ErrorResult = new AuthenticationFailureResult("Invalid username or password", request);
            }
            else
            {
                // Authentication was attempted and succeeded. Set Principal to the authenticated user.
                Realm = "Basic";
                context.Principal = principal;
            }
        }

        protected abstract Task<IPrincipal> AuthenticateAsync(string userName, string password,
            CancellationToken cancellationToken);

        private static Tuple<string, string> ExtractUserNameAndPassword(string authorizationParameter)
        {
            byte[] credentialBytes;

            try
            {
                credentialBytes = Convert.FromBase64String(authorizationParameter);
            }
            catch (FormatException)
            {
                return null;
            }

            // The currently approved HTTP 1.1 specification says characters here are ISO-8859-1.
            // However, the current draft updated specification for HTTP 1.1 indicates this encoding is infrequently
            // used in practice and defines behavior only for ASCII.
            Encoding encoding = Encoding.ASCII;
            // Make a writable copy of the encoding to enable setting a decoder fallback.
            encoding = (Encoding)encoding.Clone();
            // Fail on invalid bytes rather than silently replacing and continuing.
            encoding.DecoderFallback = DecoderFallback.ExceptionFallback;
            string decodedCredentials;

            try
            {
                decodedCredentials = encoding.GetString(credentialBytes);
            }
            catch (DecoderFallbackException)
            {
                return null;
            }

            if (String.IsNullOrEmpty(decodedCredentials))
            {
                return null;
            }

            int colonIndex = decodedCredentials.IndexOf(':');

            if (colonIndex == -1)
            {
                return null;
            }

            string userName = decodedCredentials.Substring(0, colonIndex);
            string password = decodedCredentials.Substring(colonIndex + 1);
            
            return new Tuple<string, string>(userName, password);
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            Challenge(context);
            return Task.FromResult(0);
        }

        private void Challenge(HttpAuthenticationChallengeContext context)
        {
            string parameter;

            if (String.IsNullOrEmpty(Realm))
            {
                parameter = null;
            }
            else
            {
                // A correct implementation should verify that Realm does not contain a quote character unless properly
                // escaped (precededed by a backslash that is not itself escaped).
                parameter = "realm=\"" + Realm + "\"";
            }

            context.ChallengeWith("Basic", parameter);
        }

        public virtual bool AllowMultiple
        {
            get { return false; }
        }
    }



    public class IdentityBasicAuthenticationAttribute : BasicAuthenticationAttribute
    {
        protected override async Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (userName != "jack" || password != "roller")
            {
                // No user with userName/password exists.
                return null;
            }

            // Create a ClaimsIdentity with all the claims for this user.
            Claim nameClaim = new Claim(ClaimTypes.Name, userName);
            List<Claim> claims = new List<Claim> { nameClaim };

            // important to set the identity this way, otherwise IsAuthenticated will be false
            // see: http://leastprivilege.com/2012/09/24/claimsidentity-isauthenticated-and-authenticationtype-in-net-4-5/
            ClaimsIdentity identity = new ClaimsIdentity(claims, "Basic");

            var principal = new ClaimsPrincipal(identity);
            return principal;
        }

    }
}