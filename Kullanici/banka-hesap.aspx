<%@ Page Title="" Language="C#" MasterPageFile="~/AnaSayfaMasterPage.master" AutoEventWireup="true" CodeFile="banka-hesap.aspx.cs" Inherits="Kullanici_banka_hesap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <title>Bank Hesap</title>
    <link href="/CssDosyalari/bankaHesap.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="Dava_div">
    <div class="bankaBilgiDiv">
        <table class="bankaBilgiTable" border="0">
            <tr>
                <td class="tg-midlee" colspan="2">
                    <asp:Label CssClass="label" runat="server">Banka Hesap</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Banka: </td>
                <td class="tg-right">
                    <asp:DropDownList ID="drpBanka" runat="server" CssClass="drplist" AutoPostBack="true" OnSelectedIndexChanged="drpBanka_SelectedIndexChanged">
                        <asp:ListItem Text="Banka"  Value="Banka"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Hesap Türü: </td>
                <td class="tg-right">
                    <asp:DropDownList ID="drpHesapTuru" runat="server" CssClass="drplist"  AutoPostBack="true" OnSelectedIndexChanged="drpHesapTuru_SelectedIndexChanged">
                        <asp:ListItem Text="Hesap Türü"  Value="Hesap Türü"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Bakiye Tür: </td>
                <td class="tg-right">
                    <asp:DropDownList ID="drpBakiyeTur" runat="server" CssClass="drplist"  AutoPostBack="true" OnSelectedIndexChanged="drpBakiyeTur_SelectedIndexChanged">
                        <asp:ListItem Text="Bakiye Türü"  Value="Bakiye Türü"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Hesap Adı: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtHesapAdi" runat="server" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Hesap No: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtHesapNo"  runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">IBAN no: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtIbanNo" runat="server" TextMode="Number" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Bakiye: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtBakiye"  runat="server" TextMode="Number" ></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="tg-left">Açıklama: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtDavaAciklama" CssClass="TextBoxCssMulti" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Hesap Aktif mi: </td>
                <td class="tgright">
                    <asp:CheckBox ID="chckHesapAktif" runat="server" Checked="True"/>
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

           <%-- <asp:ListView ID="list2" runat="server">
                <ItemTemplate>--%>
                    <div class="davaListeDiv">
                        <asp:Table ID="kisibilgi" CssClass="AltDivTablo" runat="server">
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Banka: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblBanka" runat="server" Text='<%#Eval("banka") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Hesap Türü </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblHesapTuru" runat="server" Text='<%#Eval("hesapturu") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Bakiye Türü: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblBakiyeTur" runat="server" Text='<%#Eval("bakiyetur") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Hesap Adı: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblHesapAdi" runat="server" Text='<%#Eval("hesapadi") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Hesap No: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblHesapNo" runat="server" Text='<%#Eval("hesapno") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>IBAN No: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblIban" runat="server" Text='<%#Eval("iban") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Hesap Bakiye: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblHesapBakiye" runat="server" Text='<%#Eval("bakiye") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Açıklama: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblAciklama" runat="server" Text='<%#Eval("aciklama") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Aktif mi: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblAktif" runat="server" Text='<%#Eval("aktif") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
               <%-- </ItemTemplate>
            </asp:ListView>--%>

        </div>

    </div>
</asp:Content>

