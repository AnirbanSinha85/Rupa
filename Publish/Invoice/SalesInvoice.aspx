<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="SalesInvoice.aspx.cs" Inherits="Rupa.Invoice.SalesInvoice" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
                <ProgressTemplate>
                    <%--<div id="dvProgress" runat="server" style="position: absolute; top: 300px; left: 550px; text-align: center;">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/ajax-loader.gif" />
                    </div>--%>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div align="center">
                <table style="width: 99%;" class="tbl_style">
                    <tr>
                        <td colspan="6" class="tbl_Header">
                            SALES INVOICE
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Client Name
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="true"
                                onselectedindexchanged="ddlClient_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlClient"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                        <td align="left">
                            Bill Date
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtBillDate" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="txtInvoiceDate_CalendarExtender" runat="server" TargetControlID="txtBillDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBillDate"
                                ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                        </td>
                        
                    </tr>
                    <tr>
                        <td align="left">
                            Address
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                             <asp:Label ID="lblAddress" runat="server" ></asp:Label>
                        </td>
                        <td align="left">
                            BillNo
                        </td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                            <asp:Label ID="lblBillNo" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            Ph-No</td>
                        <td align="left">
                            :
                        </td>
                        <td align="left">
                                <asp:Label ID="lblPhNo" runat="server" ></asp:Label>
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="6">
                            <table width="100%">
                                <tr>
                                    <td>
                                        Qty
                                    </td>
                                    <td>
                                        Unit
                                    </td>
                                    <td>
                                        Product
                                    </td>
                                    <td>
                                        Size
                                    </td>
                                    <td>
                                        Rate
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtQty" runat="server" Width="56px" MaxLength="4"></asp:TextBox>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"
                                            TargetControlID="txtQty">
                                        </asp:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtQty"
                                            ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlUnit" runat="server">
                                            <asp:ListItem Text="PCS." Value="1"></asp:ListItem>
                                            <asp:ListItem Text="BOX" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProduct" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlSize" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRate" runat="server" Width="56px" MaxLength="5"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtRate"
                                            ErrorMessage="RequiredFieldValidator" ValidationGroup="V">*</asp:RequiredFieldValidator>
                                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers" 
                                            TargetControlID="txtRate">
                                        </asp:FilteredTextBoxExtender>
                                    </td>
                                    <td>
                                        <asp:Button ID="cmdAdd" runat="server"  Text="Add" ValidationGroup="V" 
                                            onclick="cmdAdd_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="overflow: scroll; height: 150px;">
                <asp:GridView ID="gvPurcase_Invoice" runat="server" CellPadding="3" Width="100%"
                    DataKeyNames="SalesInvoiceID" GridLines="Horizontal" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" 
                    BorderWidth="1px" onrowdeleting="gvPurcase_Invoice_RowDeleting">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgbtnDelete" CommandName="Delete" Text="Edit" runat="server"
                                    ImageUrl="~/images/delete.jpg" ToolTip="Delete" Height="20px" Width="20px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Qty" HeaderText="Qty" />
                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                        <asp:BoundField DataField="ProductName" HeaderText="ProductName" />
                        <asp:BoundField DataField="SizeName" HeaderText="SizeName" />
                        <asp:BoundField DataField="Rate" HeaderText="Rate" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                        <%--   <asp:BoundField DataField="Quantity_In_Box" HeaderText="Quantity (CASE)" />--%>
                        <%-- <asp:BoundField DataField="Rate" HeaderText="Rate">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Standerd_Rebet" HeaderText="Discount Per Case">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Amount" HeaderText="Amount">
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>--%>
                    </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" HorizontalAlign="Left" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                </asp:GridView>
            </div>
            <div align="right">
                <table>
                    <tr>
                        <td>
                            Grand Total
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtGrandTotal" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                             Discount
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtDiscount" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Total
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotal" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Paid Amount</td>
                        <td>
                            :</td>
                        <td>
                             <asp:TextBox ID="txtPaidAmount" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            Due Amount</td>
                        <td>
                            :</td>
                        <td>
                            <asp:TextBox ID="txtDueAmount" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="cmdSave" runat="server" Text="Save Invoice" 
                                onclick="cmdSave_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
