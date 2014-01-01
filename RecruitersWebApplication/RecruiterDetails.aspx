<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecruiterDetails.aspx.cs" Inherits="RecruitersWebApplication.RecruiterDetails" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-2.0.3.min.js"></script>
    <%--<script src="Scripts/jquery-1.9.1.js"></script>--%>
    <script src="Scripts/app.js"></script>
    <script src="Scripts/jquery-ui-1.10.3.custom.min.js"></script>
    <link href="Content/app.css" rel="stylesheet" />
    <link href="Content/jquery-ui-1.10.3.custom.min.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            $('#<%=tbCompanyName.ClientID%>').autocomplete({
               source: function (request, response) {
                   $.ajax({
                       url: "RecruiterService.asmx/GetRecruiterNames",
                       data: "{'searchText':'" + request.term + "'}",
                       type: "POST",
                       dataType: "json",
                       contentType: "application/json;charset=utf-8",
                       success: function (data) {
                           //to prevent json hijacking we use data.d
                           response(data.d);
                       },
                       error: function (result) {
                           alert('Oops!! There is a problem processing your request' + result);
                       }
                   });
               }
           });
       });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="pageWrapper">
            <div id="leftPanel">
                <label id="lbCompanyName" title="" class="lblForm">Please type Company Name here :</label>
                <asp:TextBox ID="tbCompanyName" runat="server" CssClass=""></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
               <%-- <input type="text" id="tbCompanyName" runat="server" />--%>
                <div id="flip">Click here for advanced search</div>
                <div id="panel">
                    <label id="lbCompanySpecialists" title="" class="lblForm">Please select Company Specialists :</label>
                    <asp:DropDownList ID="ddlCompanySpecialists" runat="server" OnSelectedIndexChanged="ddlCompanySpecialists_SelectedIndexChanged"></asp:DropDownList>
                    <label id="lbCategoryType" title="" class="lblForm">Please select Category Type :</label>
                    <asp:DropDownList ID="ddlCategoryType" runat="server" OnSelectedIndexChanged="ddlCategoryType_SelectedIndexChanged" CssClass="ddlForm"></asp:DropDownList>
                    <label id="lbOfficeLocation" title="" class="lblForm">Please select Office Location here :</label>
                    <asp:DropDownList ID="ddlOfficeLocation" runat="server" OnSelectedIndexChanged="ddlOfficeLocation_SelectedIndexChanged" CssClass="ddlForm"></asp:DropDownList>
                </div>
                
                <asp:Button ID="btnAdvancedSearch" runat="server" Text="AdvancedSearch" OnClick="btnAdvancedSearch_Click" />
            </div>
            <div id="displayData" class="gvForm">
                <asp:GridView ID="gvRecruiters" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" OnPageIndexChanging="gvRecruiters_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>

                    <EditRowStyle BackColor="#2461BF"></EditRowStyle>

                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></FooterStyle>

                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"></HeaderStyle>

                    <PagerStyle HorizontalAlign="Center" BackColor="#2461BF" ForeColor="White"></PagerStyle>

                    <RowStyle BackColor="#EFF3FB"></RowStyle>

                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                    <SortedAscendingCellStyle BackColor="#F5F7FB"></SortedAscendingCellStyle>

                    <SortedAscendingHeaderStyle BackColor="#6D95E1"></SortedAscendingHeaderStyle>

                    <SortedDescendingCellStyle BackColor="#E9EBEF"></SortedDescendingCellStyle>

                    <SortedDescendingHeaderStyle BackColor="#4870BE"></SortedDescendingHeaderStyle>
                </asp:GridView>
                <asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
