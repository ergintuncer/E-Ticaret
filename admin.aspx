<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin</title>
    <link href="admin.css" rel="stylesheet"/>
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
</head>
<body>
<form id="form1" runat="server">
<div class="admindiv">
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

     <asp:Panel ID="PaylasimSilmePanel" CssClass="panel" runat="server" z-index="3">

         <asp:ListView ID="list2" runat="server">
              <ItemTemplate>
                   <div class="paylasimayar" id="paylasimayar">
                       <div class="paylasimHeaderayar">
                          <div class="ayarheadersol">
                             <asp:Label ID="lblpaylasimHeaderAdi" CssClass="lblpaylasimHeaderAdi" runat="server" Text='<%#Eval("ad_soyad") %>' ></asp:Label>
                          </div>
                          <div class="ayarheadersag" id="kabuşEt">
                              <button runat="server" id="kabulEt" onserverclick="Onayla_OnClick" class="kabulEt" title="Onayla">
                                <i class="fa fa-check fa-2x"> </i>
                              </button>
                              <button runat="server" id="reddet" onserverclick="sil_OnClick" class="reddet" title="Sil">
                               <i class="fa fa-trash fa-2x"> </i>
                              </button>
                          </div>
                       </div>

                       <div class="paylasimIcerikayar">
                <asp:Table ID="kisibilgi" runat="server">
                     <asp:TableRow ID="Label" class="kisiBilgitablerow" runat="server">
                           <asp:TableCell><b>Kimlik Numarası:</b>  </asp:TableCell>
                            <asp:TableCell> 
                                <asp:Label ID="TcKimlikNo" CssClass="kisiBilgi" runat="server" Text='<%#Eval("tck") %>'></asp:Label>
                            </asp:TableCell>
                     </asp:TableRow>

                    <asp:TableRow ID="TableRow1" class="kisiBilgitablerow" runat="server">
                           <asp:TableCell><b>Firma Bilgisi :</b></asp:TableCell>
                            <asp:TableCell> 
                                <asp:Label ID="firma" CssClass="kisiBilgi" runat="server" Text='<%#Eval("firma") %>'></asp:Label>
                            </asp:TableCell>
                     </asp:TableRow>

                    <asp:TableRow ID="TableRow2" class="kisiBilgitablerow" runat="server">
                           <asp:TableCell><b>Baro Bilgisi:</b>  </asp:TableCell>
                            <asp:TableCell> 
                                <asp:Label ID="baroBilgi" CssClass="kisiBilgi" runat="server" Text="Baro Bilgisi"></asp:Label>
                            </asp:TableCell>
                     </asp:TableRow>

                     <asp:TableRow ID="TableRow3" class="kisiBilgitablerow" runat="server">
                           <asp:TableCell><b> Numarası: </b></asp:TableCell>
                            <asp:TableCell> 
                                <asp:Label ID="sicilNo" CssClass="kisiBilgi" runat="server" Text="Sicil Numarası"></asp:Label>
                            </asp:TableCell>
                     </asp:TableRow>

                     <asp:TableRow ID="TableRow4" class="kisiBilgitablerow" runat="server">
                           <asp:TableCell><b>Birlik Sicil Numarası: </b></asp:TableCell>
                            <asp:TableCell> 
                                <asp:Label ID="birlikSicilNumarası" CssClass="kisiBilgi" runat="server" Text="Birlik Sicil Bilgisi"></asp:Label>
                            </asp:TableCell>
                     </asp:TableRow>
                </asp:Table>
                
            </div>

                   </div>

             </ItemTemplate>
         </asp:ListView>

     </asp:Panel>

</asp:Panel>
     
</div>
</div>
</div>
</form>
</body>
</html>