<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sifremiunuttum.aspx.cs" Inherits="Sayfalar_sifremiunuttum" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Şifremi Unuttum</title>
    <link href="/CssDosyalari/sifremiunuttum.css" rel="stylesheet" type="text/css"/>
</head>
<body>
<img id="bgimg" src="/image/lwbg.jpg" alt=""/>
<form id="form1" runat="server">
    <div class="girisdivi">
        <table class="giristablo" id="giristablo" border="0">
            <tbody>
            <tr>
                <td class="tg-midle" colspan="2">
                    <asp:Label CssClass="ustpanelyazi" runat="server"> Şifre Sıfırla</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tg-midlealt" colspan="2">
                    <asp:Label ID="lbl1" CssClass="hataMesajı" runat="server" Text="lbl" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                    <asp:Label CssClass="ustpanelyazi"  runat="server"> Tc No:</asp:Label>
                </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtemail" CssClass="auto-style1" runat="server" MaxLength="40"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                </td>
                <td class="tg-right">
                    <asp:Button ID="giris" CssClass="button" runat="server" Text="Yeni Şifre Al" OnClick="sifreyiSifirlaClick"/>
                     </td>
            </tr>
            </tbody>
        </table>
    </div>
</form>
</body>
</html>
