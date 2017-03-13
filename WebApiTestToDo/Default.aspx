<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookaHotel._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Book hotels</h2>
        <asp:Table runat="server" HorizontalAlign="Center">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Hotel name or destination"/>
                </asp:TableCell><asp:TableCell>
                    <asp:TextBox name="CityAjaxH" runat="server" style="height:50px"/>
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" ID="SDATEH" Text="Check in date" />
                </asp:TableCell><asp:TableCell>
                    <input type="text" value="9/23/2009" style="width: 100px;height:50px"  readonly="readonly" name="Date" id="Date" class="hasDatepicker"/>
                </asp:TableCell></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Number of nights" />
                </asp:TableCell>
                    <asp:TableCell>
                     <select>
                         <option value="1">1</option>
                         <option value="2">2</option>
                         <option value="3">3</option>
                         <option value="4">4</option>
                         <option value="5">5</option>
                         <option value="6">6</option>
                         <option value="7">7</option>
                         <option value="8">8</option>
                         <option value="9">9</option>
                         <option value="10">10</option>
                         <option value="11">11</option>
                         <option value="12">12</option>
                         <option value="13">13</option>
                         <option value="14">14</option>
                         <option value="15">15</option>
                     </select>
                </asp:TableCell>

                </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label runat="server" Text="Guest to stay" />
                </asp:TableCell>
                    <asp:TableCell>

                </asp:TableCell>

                </asp:TableRow>
            
            <asp:TableRow>



                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <asp:Button CssClass="searchbtn" runat="server" Text="Search" />
                </asp:TableCell></asp:TableRow></asp:Table></div>
    
    <div class="row">
        <div class="col-md-4">
            <h2>Cheap Hotels in London</h2>
            <p>
                <img src="http://www.lowestroomrates.com/images/527482_118_z.jpg" width="350" height="190">
            </p>
            <p>
                London is the capital city of the Great Britain and is the leading financial center and well known for arts, research and development, commerce, education, entertainment, fashion, finance, healthcare, media and tourism. It is the most visted city and is the cultural capital of the world.
Search the top hotels in London using above form.
            </p>
            <p>
                <a class="btn btn-default" href="http://www.lowestroomtares.com/hotels/London.html">See now &raquo;</a>
            </p>
        </div>
        
        <div class="col-md-4">
            <h2>Cheap Hotels in Dubai</h2><p>
                <img src="http://www.lowestroomrates.com/images/527498_165_z.jpg" width="350" height="190"> </p><p>
                Dubai one of the seven emirate of United Arab Emirates is the most populous city and the business capital. It has high rise skyscrapers including Burj Khalifa. Dubai has become a popular business and tourist destination with great shopping malls, beaches, real estate, and financial services. Popular places include Deira, BurJuman Mall, Mall of the Emirates, Dubai Marina Mall, Bur Dubai, Deira City Centre. </p><p>
                    <a class="btn btn-default" href="http://www.lowestroomtares.com/hotels/Dubai.html">See now &raquo;</a> </p></div><div class="col-md-4">
            <h2>Cheap Hotels in Las Vegas</h2><p>
                <img src="http://www.lowestroomrates.com/images/hotels/41078_79_z.jpg" width="350" height="190"> </p><p>
                Las Vegas City - The Entertainment Capital of the World is located in the state of Nevada of United States. The city is famous for its lively atmosphere, casinos & fun, hotels, museums and resorts. The popular places in Las Vegas are Paradise, Convention Center, Fremont Street - Downtown, South of The Strip, Summerlin, West of The Strip, Hughes Center, Bracken, Fashion Show Mall, Boulder Strip, Thomas and Mack Center, Premium Outlets, The Lakes, Winchester, Mini Grand Prix and Henderson - Green Valley. </p><p>
                <a class="btn btn-default" href="http://www.lowestroomrates.com/hotels/las-vegas.html">See now &raquo;</a> </p></div>

                                                                 </div>



</asp:Content>