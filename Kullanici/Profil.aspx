<%@ Page Title="Profil" Language="C#" MasterPageFile="~/AnaSayfaMaster.master" AutoEventWireup="true" CodeFile="profil.aspx.cs" Inherits="Kullanici_Profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:ScriptManager ID="MainScriptManager" runat="server"/>
<asp:UpdatePanel ID="pnlHelloWorld" runat="server">
<ContentTemplate>
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
    <div class="alert alert-success alert-dismissible fade show" role="alert" id="successalert" runat="server" Visible="False">
        Kayıt Ekleme işlemi başarı ile tamalandı.
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
    </div>
    <div class="alert alert-danger alert-dismissible fade show" role="alert" id="dangeralert" runat="server" Visible="False">
        <asp:Label ID="lblHata" runat="server" Text="Hay aksi. Bir hata oluştu."></asp:Label>
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
    </div>
    <div class="lineOrta">
        <button runat="server" id="btnDuzenle" class="btn btn-outline-success" OnServerClick="btnDuzenle_Click" Text="Düzenle">Düzenle </button>
    </div>
    <div class="progress">
        <div class="progress-bar bg-success" role="progressbar"  style="width: 0%" aria-valuenow="100" aria-valuemin="0" aria-valuemax="100" id="progress" runat="server">
            <asp:Label ID="lblProfilDolulukYuzesi" runat="server" Text="25%"></asp:Label>
        </div>
    </div>
</div>
<asp:Panel ID="pnlProfil" runat="server">
<div class="altDiv">

<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label9" runat="server" Text="Adı: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtAdi" MaxLength="50" runat="server" AutoCompleteType="FirstName"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label26" runat="server" Text="Soyadı: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtSoyadi" MaxLength="50" runat="server" AutoCompleteType="LastName"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label10" runat="server" Text="Tc Kimlik No: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox ID="txtTck" CssClass="TexBoxCss" TextMode="Number" MaxLength="11" OnTextChanged="tcNo_OnTextChanged" AutoCompleteType="Disabled" ReadOnly="True" AutoPostBack="True" runat="server"></asp:TextBox>
        <br/> 
        <asp:Label ID="lblOnTextChanged" runat="server" Visible="False" ForeColor="#F50057"></asp:Label>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label12" runat="server" Text="Firma: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtFirma" MaxLength="50" runat="server" AutoCompleteType="Company"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label13" runat="server" Text="Vergi No: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtVergiNo" MaxLength="10" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label14" runat="server" Text="Vergi Daire: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtVergiDaire" MaxLength="50" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label15" runat="server" Text="Anne Adı: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtAnneAdi" MaxLength="20" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label16" runat="server" Text="Baba Adı: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtBabaAdi" MaxLength="20" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label11" runat="server" Text="Doğum Yeri: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtDogumYeri" MaxLength="20" runat="server" AutoCompleteType="HomeCity"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label17" runat="server" Text="Doğum Tarihi: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtDogumTarihi" runat="server" TextMode="Date" AutoCompleteType="Disabled"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label18" runat="server" Text="Cinsiyet: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:DropDownList ID="drpCinsiyet" CssClass="drplist" AutoPostBack="true" runat="server">
            <asp:ListItem Value="Erkek" Text="Erkek"></asp:ListItem>
            <asp:ListItem Value="Kadın" Text="Kadın"></asp:ListItem>
        </asp:DropDownList>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label19" runat="server" Text="Din: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtDin" MaxLength="20" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label20" runat="server" Text="Medeni Hal: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:DropDownList ID="drpMedeniHal" CssClass="drplist" AutoPostBack="true" runat="server">
            <asp:ListItem Value="Bekar" Text="Bekar"></asp:ListItem>
            <asp:ListItem Value="Evli" Text="Evli"></asp:ListItem>
        </asp:DropDownList>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label21" runat="server" Text="Uyruk: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtUyruk" MaxLength="20" runat="server" AutoCompleteType="HomeCountryRegion"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label22" runat="server" Text="Kan Grubu: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:DropDownList ID="drpKanGrubu" CssClass="drplist" AutoPostBack="true" runat="server">
            <asp:ListItem Value="A Rh (+)" Text="A Rh (+)"></asp:ListItem>
            <asp:ListItem Value="A Rh (-)" Text="A Rh (-)"></asp:ListItem>
            <asp:ListItem Value="B Rh (+)" Text="B Rh (+)"></asp:ListItem>
            <asp:ListItem Value="B Rh (-)" Text="B Rh (-)"></asp:ListItem>
            <asp:ListItem Value="AB Rh (+)" Text="AB Rh (+)"></asp:ListItem>
            <asp:ListItem Value="AB Rh (-)" Text="AB Rh (-)"></asp:ListItem>
            <asp:ListItem Value="0 Rh (+)" Text="0 Rh (+)"></asp:ListItem>
            <asp:ListItem Value="0 Rh (-)" Text="0 Rh (-)"></asp:ListItem>
        </asp:DropDownList>
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
        <asp:TextBox CssClass="TexBoxCss" ID="txtMahalle" MaxLength="50" runat="server" AutoCompleteType="HomeCity"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label27" runat="server" Text="Cilt No: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtCiltNo" MaxLength="15" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label28" runat="server" Text="Aile Sıra No: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtAileSiraNo" MaxLength="15" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label29" runat="server" Text="Sira No: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtSiraNo" MaxLength="15" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label30" runat="server" Text="Verildiği Yer: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtVerildigiYer" MaxLength="50" runat="server" AutoCompleteType="HomeCity"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label31" runat="server" Text="Veriliş Nedeni: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtVerilisNedeni" MaxLength="50" runat="server" AutoCompleteType="Enabled"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label32" runat="server" Text="Kayıt No: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtKayitNo" MaxLength="15" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
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
        <asp:TextBox CssClass="TexBoxCss" ID="txtVerenMakam" MaxLength="50" runat="server" AutoCompleteType="Enabled"></asp:TextBox>
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
        <asp:TextBox CssClass="TextBoxCssMulti" ID="txtAciklama" MaxLength="250" runat="server" TextMode="MultiLine" AutoCompleteType="Notes"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label37" runat="server" Text="Adres Adı: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtAdresAdi" MaxLength="50" runat="server" AutoCompleteType="Enabled"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label38" runat="server" Text="Adres: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TextBoxCssMulti" ID="txtAdres" MaxLength="250" runat="server" TextMode="MultiLine" AutoCompleteType="BusinessStreetAddress"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label39" runat="server" Text="Telefon Adı: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtTelefonAdi" MaxLength="50" runat="server" AutoCompleteType="Enabled"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label40" runat="server" Text="Telefon: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtTelefon" MaxLength="11" TextMode="Phone" runat="server"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label41" runat="server" Text="Mail Adı: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtMailAdi" MaxLength="50" runat="server" AutoCompleteType="Enabled"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label42" runat="server" Text="Mail Adresi: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtMailadresi" MaxLength="100" runat="server" AutoCompleteType="Email"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label43" runat="server" Text="Web Adresi Adı: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtWebAdresiAdi" MaxLength="50" runat="server" AutoCompleteType="Enabled"></asp:TextBox>
    </div>
</div>
<div class="line">
    <div class="lineSolDiv">
        <asp:Label ID="Label44" runat="server" Text="Web Adresi: "></asp:Label>
    </div>
    <div class="lineSagDiv">
        <asp:TextBox CssClass="TexBoxCss" ID="txtWebAdresi" MaxLength="250" runat="server" AutoCompleteType="BusinessUrl"></asp:TextBox>
    </div>
</div>
<div class="lineOrta">
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAdi" ErrorMessage="İsim Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSoyadi" ErrorMessage="Soyisim Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTck" ErrorMessage="Tc Kimlik Numarası Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFirma" ErrorMessage="Firma Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtVergiNo" ErrorMessage="Vergi Numarası Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtVergiDaire" ErrorMessage="Vergi Dairesi Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDogumTarihi" ErrorMessage="Geçerli bir doğum tarih giriniz" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtVerilisTarih" ErrorMessage="Geçerli birveriliş  tarih giriniz" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtGecerlilikTarih" ErrorMessage="Geçerli bir geçerlilik tarih giriniz" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtAdres" ErrorMessage="Adres Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMailAdi" ErrorMessage="E-Mail Alanı Boş Geçilemez" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" CssClass="validationSummary"/>
</div>
<div class="lineOrta">
    <button runat="server" id="btnKaydet" class="btn btn-warning" OnServerClick="btnKaydet_Click" Text="Kaydet">
        Kaydet
    </button>
</div>
</div>
</asp:Panel>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>