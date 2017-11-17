<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ana Sayfa.aspx.cs" Inherits="Ana_Sayfa" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AnaSayfa</title>
    <link href="/CssDosyalari/anasayfa.css" rel="stylesheet"/>
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
</head>
<body>
<form id="form1" runat="server">
<div class="anasayfadiv">
<div class="nav">
    <div id="profildiv" class="profildiv">
        <img id="adminimg" class="adminimg" src="image/lawyerpng.png" alt=""/>
        <button runat="server" id="btnyonetici" class="btnyonetici" onserverclick="Profil_OnClick" title="Admin"> <%--resim değişecek--%>
            <asp:Label ID="lblAdminAdi" CssClass="lblAdminAdi" runat="server">Avukat Adı</asp:Label>
            <br/>
            <asp:Label ID="lbladminstatu" CssClass="lbladminstatu" runat="server"> Yönetici </asp:Label>
        </button>
    </div>

    <div id="analizdiv" class="analizdiv">
        <button runat="server" id="btnanaliz" onserverclick="Analiz_OnClick" class="navbutton" title="Kayıt">
           <i class="fa fa-user-plus fa-2x"></i>Kayıt</button>
    </div>

    <div id="Kullaniciayarlaridiv" class="Kullaniciayarlaridiv">
        <button runat="server" id="btnKullaniciayarlari" onserverclick="KullaniciAyarlari_OnClick" class="navbutton" title="Kullanıcı Ayarları">
            <i class="fa fa-users fa-2x"></i> Kullanıcı Ayarları
        </button>
    </div>

    <div id="etkinlikayarlaridiv" class="etkinlikayarlaridiv">
        <button runat="server" id="btnetkinlikayarlari" onserverclick="EtkinlikAyarlari_OnClick" class="navbutton" title="Etkinlik Ayarları">
            <i class="fa fa-calendar-check-o fa-2x"></i> Etkinlik Ayarları
        </button>
    </div>

    <div id="paylasimayarlaridiv" class="paylasimayarlaridiv">
        <button runat="server" id="btnpaylasimayarlar" onserverclick="PaylasimAyarlari_OnClick" class="navbutton" title="Paylaşım Ayarları">
            <i class="fa fa-share-square-o fa-2x"></i> Paylaşım Ayarları
        </button>
    </div>

    <div id="cikisdiv" class="cikisdiv">

        <button runat="server" id="btncikis" class="navbutton" onserverclick="Profil_Cikis_OnClick" title="Çıkış yap">
            <i class="fa fa-sign-out fa-rotate-180 fa-2x"></i> Çıkış yap
        </button>
    </div>
</div>   <%--Sol menü--%>
<div class="adminmain">
<div class="paneldiv">

<asp:Panel ID="AnalizPanel" CssClass="panel" runat="server" z-index="1">

</asp:Panel>
     
</div>
</div>
</div>
</form>
</body>
</html>
