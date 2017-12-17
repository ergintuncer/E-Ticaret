<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giriş</title>
    <link href="/CssDosyalari/login.css" rel="stylesheet" type="text/css"/>
    <link href="/CssDosyalari/AnaSayfaMaster.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" type="text/css" href="/js/bootstrap/css/bootstrap.min.css"/>
    
    <link rel='stylesheet prefetch' href='http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/themes/smoothness/jquery-ui.css'>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/prefixfree/1.0.7/prefixfree.min.js"></script>
    <link href="/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
<img id="bgimg" src="image/lawyer.jpg" alt=""/>
<form id="form1" runat="server">
    <div class="girisdivi">
        <div class="lineOrta" style="border-bottom: solid silver thin; margin-bottom: 2%;">
            <asp:Label CssClass="label" runat="server" Text="Şifre Sıfırlama" Font-Size="200%">AvukatBook <br/> Giriş</asp:Label>
        </div>
        <div class="lineOrta" style="padding: 2%;">
            <input type="number" id="txtTcNo" runat="server" class="form-control" maxlength="11" placeholder="Tc Kimlik Numaranız..."/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTcNo" ErrorMessage="Tc Kimlik Numarası Giriniz" SetFocusOnError="True" Display="Dynamic" ForeColor="#F50057"></asp:RequiredFieldValidator>
        </div>
        <div class="lineOrta" style="padding: 2%;">
            <input type="password" id="txtSifre" runat="server" class="form-control" placeholder="Şifreniz..."/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSifre" ErrorMessage="Şifre Giriniz" SetFocusOnError="True" Display="Dynamic" ForeColor="#F50057"></asp:RequiredFieldValidator>
        </div>
        <div class="line">
            <div class="lineSolDiv" style="width: 50%;">
                <asp:Button ID="btn" CausesValidation="True" CssClass="btn btn-success" runat="server" Text="Giriş" OnClick="giris_Click"/>
            </div>
            <div class="lineSagDiv" style="width: 50%;">
                <button type="button" CausesValidation="False" class="btn btn-danger" runat="server" OnServerClick="kayitol_Click">Kayıt Ol</button>
            </div>
        </div>
        <div class="lineOrta">
            <button type="button" CausesValidation="False" class="sifremiunuttum" runat="server" OnServerClick="sifremiUnuttum_Click">Şifremi unuttum</button>
        </div>
        <div class="alert alert-danger alert-dismissible fade show" role="alert" id="dangeralert" runat="server" Visible="False">
            <asp:Label ID="lblHata" runat="server"></asp:Label>
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
    </div>

</form>
</body>
</html>