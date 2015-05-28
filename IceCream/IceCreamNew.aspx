<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IceCreamNew.aspx.cs" Inherits="IceCream.IceCreamNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="content">
<div class="post"><h2 class="title"><a>BILL OF MATERIAL</a></h2>
    <div>
    
    
    <table>
    <tr>
    <td style="width:30%" >Production No.</td><td style=" width:50%;" ><asp:TextBox ID="txtproductionno" runat="server" Width="30%"></asp:TextBox>
    </td>
    <td>Quantity</td><td><asp:TextBox id="txtqua1" runat="server"></asp:TextBox></td>
    <td><asp:DropDownList ID="ddlunit" runat="server"></asp:DropDownList></td>
    </tr>
    <tr><td>Finish Good</td><td><asp:DropDownList ID="ddlfinishgood" runat="server">
        <asp:ListItem></asp:ListItem>
        </asp:DropDownList></td></tr>
    <tr>
    <td style="width:30%" >Product Description</td><td style=" width:50%;" ><asp:TextBox ID="txtdiscription" runat="server" Width="70%"></asp:TextBox>
    </td>
    <td>BOM Type</td><td><asp:DropDownList id="ddlbom" runat="server">
        <asp:ListItem>Production</asp:ListItem>
        </asp:DropDownList></td>
    </tr>
    </table>
    <table style="padding-top:10%">
    <tr>
    <td>
        <asp:ScriptManager ID="tolkitmngr" runat="server" EnablePartialRendering="false"></asp:ScriptManager>
        <%--<ajaxToolkit:ToolkitScriptManager ID="tolkitmngr" runat="server" EnablePartialRendering="false"></ajaxToolkit:ToolkitScriptManager>--%>
       <asp:UpdatePanel ID="up1" runat="server">
       <ContentTemplate>
        <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" 
          Height="65px" ShowFooter="True" BackColor="#DEBA84" BorderColor="#DEBA84" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" 
             onrowdeleting="gv1_RowDeleting1">
        <Columns>
       
            <asp:TemplateField HeaderText="SUB GROUP">
                <ItemTemplate> 
               
   <asp:DropDownList ID="ddlitemsubgrp" runat="server" 
                        onselectedindexchanged="ddlitemsubgrp_SelectedIndexChanged" 
                        AutoPostBack="True"></asp:DropDownList>
                       
                </ItemTemplate>
            </asp:TemplateField>
<asp:TemplateField HeaderText="ITEM"><ItemTemplate>
 <asp:DropDownList ID="ddlitemgrp" runat="server" ></asp:DropDownList>
                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="QUANTITY"><ItemTemplate>
        <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
        
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="UNIT"><ItemTemplate>
 <asp:DropDownList ID="ddlunit1" runat="server"></asp:DropDownList>
                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="DESCRIPTION">
<ItemTemplate>
        <asp:TextBox ID="txtProductionDiscription" runat="server"></asp:TextBox>
        
</ItemTemplate>


<FooterTemplate>
<asp:Button ID="btnAddRow" runat="server" Text="Add New Row" 
        onclick="btnAddRow_Click"/>
</FooterTemplate>
</asp:TemplateField>
<asp:CommandField ShowDeleteButton="true" />
           
            </Columns>
            
            
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
            
        </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>
    </td><td></td>
    </tr>
    </table>
    <table style="padding-top:5%"><tr><td><asp:Button ID="btnsave" runat="server" 
            Text="SAVE" onclick="btnsave_Click" /></td></tr></table>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
