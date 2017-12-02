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
                    <asp:TextBox ID="txtBankaAdres" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Banka Açıklama: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtBankaAciklama" runat="server" TextMode="MultiLine"></asp:TextBox>
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
        
        
         <asp:ListView ID="list2" runat="server">
        <ItemTemplate>
            <div class="paylasimayar" id="paylasimayar">
                <div class="paylasimHeaderayar">
                    <div class="ayarheadersol">
                        <asp:Label ID="lblpaylasimHeaderAdi" CssClass="lblpaylasimHeaderAdi" runat="server" Text='<%#Eval("bankaad") %>'></asp:Label>
                    </div>
                    <div class="ayarheadersag">
                        <button runat="server" id="aktiflik" onserverclick="Aktiflik_OnClick" class="fabutton" title="Aktif mi?">
                            <i class="fa fa-check fa-2x"> </i>
                        </button>

                    </div>
                </div>

                <div class="paylasimIcerikayar">
                    <asp:Table ID="kisibilgi" runat="server">
                        <asp:TableRow  class="kisiBilgitablerow" runat="server">
                            <asp:TableCell>
                                <b>Banka: </b>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lblil" CssClass="il" runat="server" Text='<%#Eval("bankaad") %>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow  class="kisiBilgitablerow" runat="server">
                            <asp:TableCell>
                                <b>Şube: </b>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lblilce" CssClass="lblilce" runat="server" Text='<%#Eval("bankasubead") %>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow  class="kisiBilgitablerow" runat="server">
                            <asp:TableCell>
                                <b>Şube Kodu: </b>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lbladresadi" CssClass="lbladresadi" runat="server" Text='<%#Eval("bankasubekod") %>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow  class="kisiBilgitablerow" runat="server">
                            <asp:TableCell>
                                <b>Telefon </b>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lbladres" CssClass="lbladres" runat="server" Text='<%#Eval("bankasubetel1") %>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow  class="kisiBilgitablerow" runat="server">
                            <asp:TableCell>
                                <b>Adres: </b>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lblaciklama" CssClass="lblaciklama" runat="server" Text='<%#Eval("bankasubeadres") %>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow  class="kisiBilgitablerow" runat="server">
                            <asp:TableCell>
                                <b>Açıklama: </b>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lblaktif" CssClass="lblaktif" runat="server" Text='<%#Eval("aciklama") %>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>

            </div>

        </ItemTemplate>
    </asp:ListView>
    


    </div>
    
   

</asp:Content>