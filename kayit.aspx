<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kayit.aspx.cs" Inherits="kayıt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Kayıt Ol</title>
    <link href="/CssDosyalari/kayit.css" rel="stylesheet" type="text/css"/>
    <link rel='stylesheet prefetch' href='http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/themes/smoothness/jquery-ui.css'/>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/prefixfree/1.0.7/prefixfree.min.js"></script>
    <link href="/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" type="text/css" href="/js/bootstrap/css/bootstrap.min.css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>

<img id="bgimg" src="image/lawyer.jpg" alt=""/>
<form id="kayit" runat="server">
    <div class="ortaDiv">
        <div class="form-row pb-1">
            <div class="col">
                <input type="text" class="form-control" id="adi" runat="server" placeholder="Adınız"/>
            </div>
        </div>
        <div class="form-row pb-1">
            <div class="col">
                <input id="soyadi" class="form-control" type="text" runat="server" placeholder="Soyadi" maxlength="10"/>
            </div>
        </div>
        <div class="form-row pb-1">
            <div class="col">
                <input id="tcno" class="form-control" type="number" runat="server" placeholder="Tc kimlik numarası" maxlength="11"/>
            </div>
        </div>
        <div class="form-row pb-1">
            <div class="col">
                <input id="email" class="form-control" type="email" runat="server" placeholder="E-Mail adresiniz" maxlength="30"/>
                </div>
        </div>
        <div class="form-row pb-1">
            <div class="col">
                <input id="firma" class="form-control" type="text" runat="server" placeholder="Firma" maxlength="10"/>
            </div>
        </div>
        <div class="form-row pb-1">
            <div class="col">
                <asp:DropDownList ID="baro" CssClass="form-control" runat="server">
                    <asp:ListItem Selected="True" Text="Baro Seçiniz..."></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-row pb-1">
            <div class="col">
                <input id="sicilno" class="form-control" type="text" runat="server" placeholder="Sicil no" maxlength="10"/>
            </div>
        </div>
        <div class="form-row pb-1">
            <div class="col">
                <input id="birliksicilno" class="form-control" type="text" runat="server" placeholder="Birlik sicil no" maxlength="10"/>
            </div>
        </div>
        
        <div class="lineOrta">
            <button runat="server" id="btnDuzenle" class="btn btn-outline-success" OnServerClick="gonder_Click" Text="Kaydet">Kaydet</button>
        </div>

        <div class="alert alert-success alert-dismissible fade show" role="alert" id="successalert" runat="server" Visible="False">
            Kayıt Ekleme işlemi başarı ile tamalandı.
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
        </div>
    </div>
</form>
</body>
</html>