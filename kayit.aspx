<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kayit.aspx.cs" Inherits="kayıt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Kayıt Ol</title>
    <link href="/CssDosyalari/kayit.css" rel="stylesheet" type="text/css"/>
    <style type="text/css">
        .auto-style1 {
            text-align: left;
            width: 40%;
            height: 100%;
            color: #808080;
        }
    </style>
</head>
<body>

<img id="bgimg" src="image/lawyer.jpg" alt=""/>
<form id="kayit" runat="server">
    <div class="kayitdivi">
        <table class="kayittablo" id="kayittablo" border="0">
            <tbody>
            <tr>
                <td class="tg-midle" colspan="2">
                    <asp:Label CssClass="label" runat="server"> Avukat Kayıt </asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tg-midlealt" colspan="2">
                    <asp:Label ID="Label1" CssClass="hataMesajı" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                    <asp:Label CssClass="label" runat="server"> Adı:</asp:Label>
                </td>
                <td class="tg-right">
                    <input id="adi" class="input" type="text" runat="server" placeholder="Adı" MaxLength="10"/>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                    <asp:Label CssClass="label" runat="server"> Soyadı: </asp:Label>
                </td>
                <td class="tg-right">
                    <input id="soyadi" class="input" type="text" runat="server" placeholder="Soyadi" MaxLength="10"/>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                    <asp:Label CssClass="label" runat="server">Tc No:</asp:Label>
                </td>
                <td class="tg-right">
                    <input id="tcno" class="input" type="number" runat="server" placeholder="Tc kimlik numarası" maxlength="11"/>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                    <asp:Label CssClass="label" runat="server">Firma:</asp:Label>
                </td>
                <td class="tg-right">
                    <input id="firma" class="input" type="text" runat="server" placeholder="Firma" MaxLength="10"/>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                    <asp:Label CssClass="label" runat="server"> Baro Bilgisi: </asp:Label>
                </td>
                <td class="tg-right">
                    <asp:DropDownList ID="baro" CssClass="drplist" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label CssClass="label" runat="server">Sicil no:</asp:Label>
                </td>
                <td class="tg-right">
                    <input id="sicilno" class="input" type="text" runat="server" placeholder="Sicil no" MaxLength="10"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label CssClass="label" runat="server">Birlik sicil no:</asp:Label>

                </td>
                <td class="tg-right">
                    <input id="birliksicilno" class="input" type="text" runat="server" placeholder="Birlik sicil no" MaxLength="10"/>
                </td>
            </tr>
            <!--
            <tr>
                <td class="tg-left">
                    <asp:Label CssClass="label" runat="server"> Baro Bilgisi: </asp:Label>
                </td>
                <td class="tg-right">
                    <asp:DropDownList ID="baroq" CssClass="drplist" runat="server"></asp:DropDownList>
                </td>
            </tr>
            -->
            <tr>
                <td class="tg-left">
                    <asp:Button ID="gonder" CssClass="button" runat="server" Text="Kayıt Ol" OnClick="gonder_Click"/>

                </td>
                <td class="tg-right">
                    <asp:Button ID="girisegit" CssClass="button" runat="server" Text="Giriş Yap" PostBackUrl="~/login.aspx"/>

                </td>
            </tr>
            </tbody>
        </table>
    </div>
</form>
</body>
</html>