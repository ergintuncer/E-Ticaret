<%@ Page Title="Profil" Language="C#" MasterPageFile="~/AnaSayfaMaster.master" AutoEventWireup="true" CodeFile="profil.aspx.cs" Inherits="Kullanici_Profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <link href="/CssDosyalari/profilyeni.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="pageDisDiv">
<div class="ustDiv">
    <div class="line">
        <asp:Label ID="Label1" runat="server" Text="Adı:" Font-Bold="True"></asp:Label>
        <asp:Label ID="lblkuladi" runat="server"></asp:Label>
    </div>
    <div class="line">
        <asp:Label ID="Label2" runat="server" Text="Soyadı:" Font-Bold="True"></asp:Label>
        <asp:Label ID="lblkulsoyadi" runat="server"></asp:Label>
    </div>
    <div class="line">
        <asp:Label ID="Label3" runat="server" Text="Doğum Tarihi:" Font-Bold="True"></asp:Label>
        <asp:Label ID="lblkuldogumtarihi" runat="server"></asp:Label>
    </div>
    <div class="line">
        <asp:Label ID="Label4" runat="server" Text="Tc Kimlik Numarası:" Font-Bold="True"></asp:Label>
        <asp:Label ID="lblkulTcKimlikNo" runat="server"></asp:Label>
    </div>
    <div class="line">
        <asp:Label ID="Label5" runat="server" Text="Firma:" Font-Bold="True"></asp:Label>
        <asp:Label ID="lblkulFirma" runat="server"></asp:Label>
    </div>
    <div class="line">
        <asp:Label ID="Label6" runat="server" Text="Telefon No:" Font-Bold="True"></asp:Label>
        <asp:Label ID="lblkulTelNo" runat="server"></asp:Label>
    </div>
    <div class="line">
        <asp:Label ID="Label7" runat="server" Text="E-Mail:" Font-Bold="True"></asp:Label>
        <asp:Label ID="lblkulMail" runat="server"></asp:Label>
    </div>
    <div class="line">
        <asp:Label ID="Label8" runat="server" Text="Web Adresi:" Font-Bold="True"></asp:Label>
        <asp:Label ID="lblkulWebAdresi" runat="server"></asp:Label>
    </div>
    <div class="lineOrta">
        <button runat="server" id="btnDuzenle" class="button" Text="Düzenle">
            <i class="fa fa-edit fa-2x"></i>Düzenle
        </button>
    </div>

</div>
<asp:Panel ID="pnlProfil" runat="server">
<div class="altDiv">

<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label9" runat="server" Text="Adı: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtAdi" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label26" runat="server" Text="Soyadı: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtSoyadi" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label10" runat="server" Text="Tc Kimlik No: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtTck" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label12" runat="server" Text="Firma: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtFirma" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label13" runat="server" Text="Vergi No: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtVergiNo" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label14" runat="server" Text="Vergi Daire: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtVergiDaire" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label15" runat="server" Text="Anne Adı: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtAnneAdi" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label16" runat="server" Text="Baba Adı: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtBabaAdi" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label11" runat="server" Text="Doğum Yeri: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtDogumYeri" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label17" runat="server" Text="Doğum Tarihi: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtDogumTarihi" runat="server" TextMode="Date"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label18" runat="server" Text="Cinsiyet: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:RadioButtonList ID="radioBTNCinsiyet" RepeatDirection="Horizontal" runat="server">
            <asp:ListItem Value="Erkek" Text="Erkek"></asp:ListItem>
            <asp:ListItem Value="Kadın" Text="Kadın"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label19" runat="server" Text="Din: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtDin" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label20" runat="server" Text="Medeni Hal: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:RadioButtonList ID="radioBtnMedeniHal" RepeatDirection="Horizontal" runat="server">
            <asp:ListItem Value="Bekar" Text="Bekar"></asp:ListItem>
            <asp:ListItem Value="Evli" Text="Evli"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label21" runat="server" Text="Uyruk: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtUyruk" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label22" runat="server" Text="Kan Grubu: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:RadioButtonList ID="radioBtnKanGrubu" RepeatDirection="Horizontal" runat="server">
            <asp:ListItem Value="A(+)" Text="A(+)"></asp:ListItem>
            <asp:ListItem Value="A(-)" Text="A(-)"></asp:ListItem>
            <asp:ListItem Value="B(+)" Text="B(+)"></asp:ListItem>
            <asp:ListItem Value="B(-)" Text="B(-)"></asp:ListItem>
            <asp:ListItem Value="AB(+)" Text="AB(+)"></asp:ListItem>
            <asp:ListItem Value="AB(-)" Text="AB(-)"></asp:ListItem>
            <asp:ListItem Value="0(+)" Text="0(+)"></asp:ListItem>
            <asp:ListItem Value="0(-)" Text="0(-)"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label23" runat="server" Text="İl: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:DropDownList ID="drpIl" CssClass="drplist" OnSelectedIndexChanged="drpIl_OnTextChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label24" runat="server" Text="İlçe: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:DropDownList ID="drpIlce" CssClass="drplist" runat="server"></asp:DropDownList>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label25" runat="server" Text="Mahalle: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtMahalle" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label27" runat="server" Text="Cilt No: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtCiltNo" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label28" runat="server" Text="Aile Sıra No: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtAileSiraNo" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label29" runat="server" Text="Sira No: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtSiraNo" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label30" runat="server" Text="Verildiği Yer: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtVerildigiYer" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label31" runat="server" Text="Veriliş Nedeni: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtVerilisNedeni" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label32" runat="server" Text="Kayıt No: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtKayitNo" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label33" runat="server" Text="Veriliş Tarih: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtVerilisTarih" runat="server" TextMode="Date"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label34" runat="server" Text="Veren Makam: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtVerenMakam" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label35" runat="server" Text="Geçerlilik Tarihi: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtGecerlilikTarih" runat="server" TextMode="Date"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label36" runat="server" Text="Açıklama: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TextBoxCssMulti" ID="txtAciklama" runat="server" TextMode="MultiLine"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label37" runat="server" Text="Adres Adı: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtAdresAdi" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label38" runat="server" Text="Adres: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TextBoxCssMulti" ID="txtAdres" runat="server" TextMode="MultiLine"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label39" runat="server" Text="Telefon Adı: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtTelefonAdi" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label40" runat="server" Text="Telefon: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtTelefon" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label41" runat="server" Text="Mail Adı: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtMailAdi" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label42" runat="server" Text="Mail Adresi: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtMailadresi" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label43" runat="server" Text="Web Adresi Adı: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtWebAdresiAdi" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label44" runat="server" Text="Web Adresi: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtWebAdresi" runat="server"></asp:TextBox>
    </div>
</div>
<div class="lineOrta">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAdi" ErrorMessage="İsim Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSoyadi" ErrorMessage="Soyisim Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTck" ErrorMessage="Tc Kimlik Numarası Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFirma" ErrorMessage="Firma Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtVergiNo" ErrorMessage="Vergi Numarası Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtVergiDaire" ErrorMessage="Vergi Dairesi Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAdres" ErrorMessage="Adres Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtMailAdi" ErrorMessage="E-Mail Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validationSummary"/>
</div>
<div class="lineOrta">
    <button runat="server" id="btnKaydet" class="button" OnServerClick="btnKaydet_Click" Text="Kaydet">
        <i class="fa fa-save fa-2x"></i>Kaydet
    </button>
</div>
</div>
</asp:Panel>
</div>

</asp:Content>