<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PatientWeb.Views.WebForm1" %>
<%@ Register assembly="DevExpress.Web.v16.2, Version=16.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<!DOCTYPE html>
<script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="Scripts/patient.js"></script>
<script>
    $(document).ready(function () {
        patient.init();
    });
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <a href="#">Add New</a>
    <div id="gridContainer">
        <table>
            <thead>
                <tr>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Id Number</th>
                    <th>Phone Number</th>
                    <th>Date of Birth</th>
                    <th>Nationality</th>
                    <th>Diseases</th>
                    <th>Blood Type</th>
                    <th>Edit</th>
                    <th>Delete</th>
                </tr>
            </thead>
            <tbody id ="patients">
            </tbody>
        </table>
    </div>
    <%--    <dx:ASPxGridView ID="grdPatients" runat="server">
            <Columns>
                <dx:GridViewCommandColumn VisibleIndex="0">
                </dx:GridViewCommandColumn>
            </Columns>
        </dx:ASPxGridView>--%>
        <div id="PatientForm">
            <input type="text" id="txtPatientId" hidden="hidden" />
            <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            <asp:Label ID="Label8" runat="server" Text="Id Number"></asp:Label>
            <asp:TextBox ID="txtIdNumber" runat="server"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Phone"></asp:Label>
            <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Date of Birth"></asp:Label>
            <asp:TextBox ID="txtDateOfBirth" runat="server"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="Nationality"></asp:Label>
            <asp:DropDownList ID="cmbCountries" runat="server"></asp:DropDownList>
            <asp:Label ID="Label6" runat="server" Text="Diseases"></asp:Label>
            <asp:TextBox ID="txtDiseases" runat="server"></asp:TextBox>
            <asp:Label ID="Label7" runat="server" Text="Blood Type"></asp:Label>
            <asp:DropDownList ID="cmbBloodTypes" runat="server"></asp:DropDownList>
            <input type="button" value="Save" onclick="patient.save()"/>
        </div>
    </form>
</body>
</html>
