<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ayarlar.aspx.cs" Inherits="ayarlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <link href="ayarlar.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div class="ayarnav">
    <%--  Sol taraftaki ayarlar menüsü--%>
    <div id="sifreislemleridiv" class="ayarlabeldiv">
        <%-- Html tipinde tanımladığım butonun onClick tanımlaması onServerClick şeklinde oluyor
            Gerekli açıklama ayarlar.aspx.cs dosyasında var--%>
        <button runat="server" id="btnsifreislemleri" onserverclick="SifreIslemleri_OnClick" class="navbutton" title="Şifre Değişrirme">
            <i class="fa fa-key fa-2x"> </i> Şifre Değişrirme
        </button>
    </div>

    <div id="profilguncellemediv" class="ayarlabeldiv">
        <button runat="server" id="btnprofilguncelleme" onserverclick="ProfilGuncelleme_OnClick" class="navbutton" title="Profil Guncelleme">
            <i class="fa fa-user fa-2x"></i> Profil Guncelleme
        </button>
    </div>

    <div id="paylasimsilme" class="ayarlabeldiv">
        <button runat="server" id="btnpaylasimsilme" onserverclick="PaylasimSilme_OnClick" class="navbutton" title="Paylaşım Silme">
            <i class="fa fa-share-alt fa-2x"></i> Paylaşım Silme
        </button>
    </div>

    <div id="etkinliksilme" class="ayarlabeldiv">
        <button runat="server" id="btnetkinliksilme" onserverclick="EtkinlikSilme_OnClick" class="navbutton" title="Etkinlik Silme">
            <i class="fa fa-calendar fa-2x"></i> Etkinlik Silme
        </button>
    </div>


</div>

<div class="paneldiv">

    <asp:Panel ID="SifreDegistirmePanel" CssClass="panel" runat="server" z-index="1">
        <%--  Şifre Değiştirme Paneli Tablo ile yaptım--%>

        <table class="sifredegistirtablo" id="sifredegistirtablo" border="0">
            <tbody>
            <tr>
                <td class="tg-midle" colspan="2">
                    <asp:Label ID="Label55" CssClass="ustpanelyazi" runat="server"> Şifre Değiştirme </asp:Label>
                </td>
            </tr>

            <tr>
                <td class="tg-left">
                    <asp:Label ID="Label1" runat="server" Text="Eski Şifreniz:"></asp:Label>
                </td>
                <td class="tg-right">
                    <asp:TextBox ID="txteskisifre" CssClass="inputnesnesi" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                    <asp:Label ID="Label2" runat="server" Text="Yeni Şifreniz:"></asp:Label>
                </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtyenisifre" CssClass="inputnesnesi" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                    <asp:Label ID="Label3" runat="server" Text="Yeni Şifreniz Tekrar:"></asp:Label>
                </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtyenisifretekrar" CssClass="inputnesnesi" TextMode="Password" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                </td>
                <td class="tg-right">
                    <asp:Button ID="btnsifredegistir" CssClass="inputnesnesi" runat="server" Text="Değiştir" onserverclick="btnsifredegistir_OnClick" OnClick="btnsifredegistir_Click"/>
                </td>
            </tr>
            </tbody>
        </table>


    </asp:Panel>


    <asp:Panel ID="ProfilGuncellemePanel" CssClass="panel" runat="server" z-index="2">

        <%--  Profil güncellemee paneli tablo ile yaptım--%>
        <table class="profilguncelletablo" id="profilguncelletablo" border="0">
            <tbody>
            <tr>
                <td class="tg-midle" colspan="2">
                    <asp:Label CssClass="ustpanelyazi" runat="server">Profil Güncelleme </asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tg-left">

                    <asp:Image ID="imgprofilresmiguncelle" CssClass="ayarlarprofilresmi" runat="server" ImageUrl="image/1.jpg" Width="100px" Height="100px"/>
                </td>
                <td class="tg-right">
                    <asp:FileUpload ID="fluDosya" runat="server" CssClass="input"/>
                    <asp:TextBox ID="txtveri" CssClass="inputnesnesi" runat="server" Visible="false"></asp:TextBox>
                    <asp:Button ID="btnkaydet" CssClass="button" runat="server" onserverclick="btnkaydet_OnClick" Text="Kaydet" OnClick="btnkaydet_Click"/>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                    <asp:Label ID="Label4" runat="server" Text="Ad:"></asp:Label>
                </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtad" CssClass="inputnesnesi" runat="server">Tuncer</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                    <asp:Label ID="Label5" runat="server" Text="Soyad:"></asp:Label>
                </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtsoyad" CssClass="inputnesnesi" runat="server">Ergin</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                    <asp:Label ID="Label6" runat="server" Text="Memleket:"></asp:Label>
                </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtmemleket" CssClass="inputnesnesi" runat="server">Alanya</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                    <asp:Label ID="Label7" runat="server" Text="Üniversite:"></asp:Label>
                </td>
                <td class="tg-right">
                    <asp:DropDownList ID="drpuniversite" CssClass="inputnesnesi" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                    <asp:Label ID="Label9" runat="server" Text="Fakülte:"></asp:Label>
                </td>
                <td class="tg-right">

                    <asp:TextBox ID="txtfakulte" CssClass="inputnesnesi" runat="server">Alanya</asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">
                    <asp:Label ID="Label8" runat="server" Text="Bölüm:"></asp:Label>
                </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtbolum" CssClass="inputnesnesi" runat="server">Alanya</asp:TextBox>
                    <asp:Button ID="btn2" CssClass="button" runat="server" onserverclick="btn2_OnClick" Text="kaydet2" OnClick="btn2_Click"/>
                </td>

            </tr>

            </tbody>
        </table>
    </asp:Panel>


    <asp:Panel ID="PaylasimSilmePanel" CssClass="panel" runat="server" z-index="3">
        <%--  Paylaşım silme paneli anasayfadakine benzer--%>

        <div class="paylasimayar" id="paylasimayar">
            <div class="paylasimHeaderayar">
                <div class="ayarheadersol">
                    <asp:Image ID="imgpaylasimHeaderResim" CssClass="imgpaylasimHeaderResim" runat="server" ImageUrl="image/1.jpg"/>
                    <asp:Label ID="lblpaylasimHeaderAdi" CssClass="lblpaylasimHeaderAdi" runat="server" Text="Tuncer Ergin"></asp:Label>
                </div>
                <div class="ayarheadersag">
                    <button runat="server" id="btnpaylasimisil" onserverclick="PaylasimiSil_OnClick" class="trash paylasimisil" title="Paylaşımı Sil">
                        <i class="fa fa-trash-o fa-2x"> </i>
                    </button>
                </div>
            </div>
            <div class="paylasimIcerikayar">
                <asp:Image ID="imgpaylasimresim" CssClass="imgpaylasimresim" ImageUrl="image/irvin.JPG" runat="server"/>
                <asp:Label ID="lblPaylasimIcerik" CssClass="lblPaylasimIcerik" runat="server" Text="Bu bir paylaşım içeriği. buna bi kısıtlama koy bütün yazı gözükmesin emş?"></asp:Label>
            </div>
            <div class="paylasimFooterayar">
                <asp:ImageButton ID="imgPaylasimiBegenButton" CssClass="imgPaylasimiBegenButton" ImageUrl="image/liked.png" runat="server"/> <%-- Beğen butonuna tıklanınca url "image/liked.png" olacak --%>
                <asp:Label ID="lblBegenmeSayisi" CssClass="lblBegenmeSayisi" runat="server" Text="10 Kişi beğendi"></asp:Label>
                <asp:Label ID="lblPaylasimTarihi" CssClass="lblPaylasimTarihi" runat="server" Text="14.11.1994"></asp:Label>
            </div>
        </div>


    </asp:Panel>

    <asp:Panel ID="EthinlikSilmePanel" CssClass="panel" runat="server" z-index="3">
        <%--  Etkinlik silme paneli etkinlik.aspx benzer--%>
       <asp:ListView ID="list1" runat="server">
           <ItemTemplate>
         <div id="etkinlikdiv" class="etkinlikdiv">
            <div class="etkinlikheader">
                <%--asasasasasasasas--%>
                <div class="etkinlikheadersol">
                    <asp:Image ID="img_etkinliksahibi" CssClass="etkinliksahibi" runat="server" ImageUrl='<%#Eval("resim")%>'/>
                    <asp:Label ID="lbl_etkinliksahibi" runat="server" Text='<%#Eval("adi_soyadi")%>'></asp:Label>
                </div>
                <div class="etkinlikheaderorta">
                    <asp:Label ID="lbl_etkinlikbaslik" runat="server" Text='<%#Eval("etkinlik_bas")%>'></asp:Label>
                </div>
                <div class="etkinlikheadersag">
                    <asp:Label ID="lbl_etkinliktarihi" runat="server" Text='<%#Eval("etkinlik_tarih")%>'></asp:Label>
                    <asp:Label ID="lbl_etkinliksaati" runat="server" Text='<%#Eval("etkinlik_saat")%>'></asp:Label>
                    <a href="Ayarlar.aspx?islem=sil&id=<%#Eval("ID") %>">
                        <img src="image/1482007936_Close_Icon.png" /></a>
                </div>
            </div>
            <div class="etkinlikicerikdiv">
                <div class="etkinliksol">
                    <asp:Image ID="img_etkinlik" CssClass="etkinlikposter" runat="server" ImageUrl='<%#Eval("etkinlik_resim")%>'/>
                </div>
                <div class="etkinliksag">
                    <asp:Label ID="lbl_etkinlikaciklama" CssClass="lbletkinlikaciklama" runat="server" Text='<%#Eval("etkinlik_icerik")%>' Font-Strikeout="False"></asp:Label>
                </div>
            </div>
            <div class="etkinlikfooter">
                <asp:Label ID="lbl_etkinlikkonumu" CssClass="lbl_etkinlikkonumu" runat="server" Text='<%#Eval("etkinlik_konum")%>'></asp:Label>
            </div>
        </div>
            </ItemTemplate>
            </asp:ListView>

    </asp:Panel>

</div>
</asp:Content>