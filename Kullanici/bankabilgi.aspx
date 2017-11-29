<%@ Page Title="" Language="C#" MasterPageFile="~/AnaSayfaMasterPage.master" AutoEventWireup="true" CodeFile="bankabilgi.aspx.cs" Inherits="Kullanici_paratransferi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <title>Banka Bilgi</title>
    <link href="/CssDosyalari/BankaBilgi.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="bankaBilgiDiv">
        <table class="bankaBilgiTable" border="0">
            <tr>
                <td class="tg-midlee" colspan="2">
                    <asp:Label CssClass="label" runat="server"> Banka Bilgi </asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Banka Adı: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtBankaAdi" runat="server"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td class="tg-left">Banka Şube: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtBankaSube" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Banka Şube Kodu: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtBankaSubeKodu" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Banka Telefon no: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtBankaTelefonNo" runat="server" TextMode="Phone"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="tg-left">Banka Telefon Kodu: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtBankaTelefonKodu" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Banka Adres: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtBankaAdres" CssClass="TextBoxCssMulti" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Banka Aktif mi: </td>
                <td class="tg-right">
                    <asp:CheckBox ID="chckBankaAktif" runat="server"/>
                </td>
            </tr>
            <tr>
                <td class="tg-buton" colspan="2">
                    <button runat="server" id="btnKaydet"  class="btnBankaKaydet" OnServerClick="btnKaydet_Click" Text="Kaydet">
                        <i class="fa fa-save fa-2x"></i>Kaydet
                    </button>
                </td>
            </tr>
        </table>


    </div>
</asp:Content>