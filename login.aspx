<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giriş</title>
    <link href="/CssDosyalari/login.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" type="text/css" href="/js/bootstrap/css/bootstrap.min.css"/>
   
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
                    <asp:TextBox ID="kullaniciadi" CssClass="form-control" runat="server" MaxLength="11"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                    <asp:Label CssClass="ustpanelyazi" runat="server"> Şifre: </asp:Label>
                </td>
                <td class="tg-right">

                    <asp:TextBox ID="sifre" CssClass="form-control" runat="server" MaxLength="11"></asp:TextBox>
                </td>
            </tr><tr>
                <td class="tg-left">
                </td>
                <td class="tg-right">
                    <button type="button" class="btn btn-success" runat="server" OnServerClick="giris_Click">Giriş</button>
                    <button type="button" class="btn btn-danger" runat="server" Text="Kayıt Ol" PostBackUrl="~/kayit.aspx" OnServerClick="kayitol_Click">Kayıt Ol</button>
                </td>
            </tr>
            <tr>
                <td class="tg-leftt">
                </td>
                <td class="tg-rightt">
                    <asp:Button ID="Button1" CssClass="sifremiunuttum" runat="server" Text="Şifremi unuttum " OnClick="sifremiUnuttum_Click"/>
                    <%--<asp:Button ID="alert" CssClass="alert" runat="server" Text="Klik"/>--%>
                </td>
            </tr>


            </tbody>
        </table>
    </div>
</form>
</body>
</html>