<%@ Page Title="" Language="C#" MasterPageFile="~/AnaSayfaMasterPage.master" AutoEventWireup="true" CodeFile="banka-hesap-tur.aspx.cs" Inherits="Kullanici_banka_hesap_tur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <title>Banka Kesap Türü</title>
    <link href="/CssDosyalari/bankaHesapTuru.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="Dava_div">
    <div class="bankaBilgiDiv">
        <table class="bankaBilgiTable" border="0">
            <tr>
                <td class="tg-midlee" colspan="2">
                    <asp:Label CssClass="label" runat="server"> Banka Hesap Türü</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Hesap Tür Adı: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtHesapTur" runat="server"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td class="tg-left">Açıklama: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtHesapTurAciklama" CssClass="TextBoxCssMulti" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-buton" colspan="2">
                    <button runat="server" id="btnKaydet" class="btnBankaKaydet" OnServerClick="btnKaydet_Click" Text="Kaydet">
                        <i class="fa fa-save fa-2x"></i>Kaydet
                    </button>
                </td>
            </tr>
        </table>
    </div>
        <div class="davaAltDiv">

        <%--    <asp:ListView ID="list2" runat="server">
                <ItemTemplate>--%>
                    <div class="davaListeDiv">
                        <asp:Table ID="kisibilgi" CssClass="AltDivTablo" runat="server">
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Banka Hesap Türü: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblBankaHesapTuru" runat="server" Text='<%#Eval("hesaptur") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Hesap Türü Hakkında: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblBankaHesapAciklama" runat="server" Text='<%#Eval("aciklama") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                <%--</ItemTemplate>
            </asp:ListView>--%>

        </div>

    </div>
</asp:Content>

