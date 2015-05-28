<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IceCream.aspx.cs" Inherits="IceCream.IceCream" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 30%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div id="content">
<div class="post"><h2 class="title"><a>BILL OF MATERIAL</a></h2>
    <div>
    
    
    <table>
    <tr>
    <td class="auto-style1" >Production No.</td><td style=" width:70%; margin-left:60%" ><asp:TextBox ID="txtprono" runat="server" Width="30%"></asp:TextBox>
    </td>
    <td>Quantity</td><td><asp:TextBox id="txtqua1" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
    <td class="auto-style1" >Product Description</td><td style=" width:70%; margin-left:60%" ><asp:TextBox ID="TextBox1" runat="server" Width="70%"></asp:TextBox>
    </td>
    <td>BOM Type</td><td><asp:DropDownList id="ddlbom" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
    <td class="auto-style1">
    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" OnRowDataBound="gv1_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="SUB GROUP">
                <ItemTemplate> 
                      <asp:DropDownList ID="ddl1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl1_SelectedIndexChanged"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ITEM">
                <ItemTemplate>
                    <asp:DropDownList ID="ddl2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl2_SelectedIndexChanged"></asp:DropDownList>
                 </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
             <ItemTemplate>
                 <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price Per Unit">
             <ItemTemplate>
                 <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </td>
    </tr>
    <tr><td class="auto-style1"><asp:Button ID="btnsave" runat="server" Text="SAVE" />
        <asp:Button ID="btnAddNew" runat="server" OnClick="btnAddNew_Click" Text="Add New" />
        </td></tr>
    </table>
    </div>
    </div>
    </div>

    </form>
</body>
</html>
