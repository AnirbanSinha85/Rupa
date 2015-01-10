<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseInvoicePrint.aspx.cs" Inherits="Rupa.Report.PurchaseInvoicePrint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
        <div align="center" style="font-family: SimSun-ExtB; font-size: medium;">
             
            <asp:Literal ID="view_Claim_print" runat="server"></asp:Literal><br />
        </div>
        <div align="center">
            <asp:Button runat="server" ID="cmdBack" Text="Back" Style="width: 70px; font-size: x-small"
                  />
            <input type="button" id="cmdPrint" value="Print" style="width: 70px; font-size: x-small"
                onclick="Print()" /></div>
    </div>
    </form>
</body>
</html>
