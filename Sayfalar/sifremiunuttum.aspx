<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sifremiunuttum.aspx.cs" Inherits="Sayfalar_sifremiunuttum" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Şifremi Unuttum</title>
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
<img id="bgimg" src="/image/lwbg.jpg" alt=""/>
<form id="form1" runat="server">
    <div class="girisdivi">
        <div class="lineOrta" style="border-bottom: solid silver thin; margin-bottom: 2%;">
            <asp:Label CssClass="label" runat="server" Text="Şifre Sıfırlama" Font-Size="200%">AvukatBook <br/> Şifre Sıfırlama</asp:Label>
        </div>
        <div class="lineOrta" style="padding: 5%; padding-top: 15%;">
            <input type="number" id="txtTcNo" runat="server" class="form-control" maxlength="11" placeholder="Tc Kimlik Numaranız..."/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTcNo" ErrorMessage="Tc Kimlik Numarası Giriniz" SetFocusOnError="True" Display="Dynamic" ForeColor="#F50057"></asp:RequiredFieldValidator>
        </div>
        <div class="line" style="width: 100%; display: inline-block;">
            <div class="lineSolDiv"  style="width: 50%; text-align: right; padding-right: 1%;">
                <asp:Button runat="server" ID="btnSifirla" CausesValidation="True" CssClass="btn btn-outline-success" OnClick="SifreyiSifirla_Click" Text="Şifreyi Sıfırla"/>
            </div>
            <div class="lineSagDiv" style="width: 50%; text-align: left; padding-left: 1%;">
                <asp:Button runat="server" CausesValidation="False" ID="btnGirisYap" CssClass="btn btn-outline-warning" OnClick="GirisYap_Click" Text="Giriş Yap"/>
            </div>
        </div>
        <div class="alert alert-danger alert-dismissible fade show" role="alert" id="dangeralert" runat="server" Visible="False">
            <asp:Label ID="lblHata" runat="server"></asp:Label>
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
        <div class="alert alert-success alert-dismissible fade show" role="alert" id="successalert" runat="server" Visible="False">
            Şifreniz E-mailinize gönderilmiştir.
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
    </div>
</form>
</body>
</html>