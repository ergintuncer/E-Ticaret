<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giriş</title>
    <link href="logincss.css" rel="stylesheet" type="text/css"/>
</head>
<body>
<img id="bgimg" src="image/lwbg.jpg" alt=""/>
<form id="form1" runat="server">
    <div class="girisdivi">
        <table class="giristablo" id="giristablo" border="0">
            <tbody>
            <tr>
                <td class="tg-midle" colspan="2">
                    <asp:Label CssClass="ustpanelyazi" runat="server"> Avukat Giriş </asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tg-midlealt" colspan="2">
                    <asp:Label ID="lbl1" CssClass="hataMesajı" runat="server" Text="lbl" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                    <asp:Label CssClass="ustpanelyazi" runat="server"> Tc No:</asp:Label>
                </td>
                <td class="tg-right">
                    <asp:TextBox ID="kullaniciadi" CssClass="auto-style1" runat="server" MaxLength="11"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                    <asp:Label CssClass="ustpanelyazi" runat="server"> Şifre: </asp:Label>
                </td>
                <td class="tg-right">
                    <asp:TextBox ID="sifre" CssClass="input" runat="server" MaxLength="11"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                </td>
                <td class="tg-right">
                    <asp:Button ID="Button1" CssClass="sifremiunuttum" runat="server" Text="Şifremi unuttum " OnClick="sifremiUnuttum_Click"/>
                </td>
            </tr>

            <tr>
                <td class="tg-left">
                </td>
                <td class="tg-right">
                    <asp:Button ID="giris" CssClass="button" runat="server" Text="Giriş" OnClick="giris_Click"/>
                    <asp:Button ID="kayitol" CssClass="button" runat="server" Text="Kayıt Ol" PostBackUrl="~/kayıt.aspx" OnClick="kayitol_Click"/>
                </td>
            </tr>
            </tbody>
        </table>
    </div>
</form>
</body>
</html>