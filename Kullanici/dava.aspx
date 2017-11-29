<%@ Page Title="" Language="C#" MasterPageFile="~/AnaSayfaMasterPage.master" AutoEventWireup="true" CodeFile="dava.aspx.cs" Inherits="Kullanici_dava" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <title>Dava</title>
    <link href="/CssDosyalari/davaTur.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="Dava_divu">
    <div class="bankaBilgiDiv">
        <table class="bankaBilgiTable" border="0">
            <tr>
                <td class="tg-midlee" colspan="2">
                    <asp:Label CssClass="label" runat="server"> Dava Türü</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Dava Türü: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtDavaTur" runat="server"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td class="tg-left">Açıklama: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtDavaAciklama" CssClass="TextBoxCssMulti" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Dava Aktif mi: </td>
                <td class="tg-right">
                    <asp:CheckBox ID="chckDavaAktif" runat="server" Checked="True"/>
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

            <asp:ListView ID="list2" runat="server">
                <ItemTemplate>
                    <div class="davaListeDiv">
                        <asp:Table ID="kisibilgi" CssClass="AltDivTablo" runat="server">
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Dava Türü: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblDavaTuru" runat="server" Text='<%#Eval("davaturad") %>'></asp:Label>
                                    <asp:Label ID="Label1" runat="server" ></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Dava Açıklama: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblDavaAciklama" runat="server" Text='<%#Eval("aciklama") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Dava Aktif mi: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblDavaAktif" runat="server" Text='<%#Eval("aktif") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Tarih: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblTarih" runat="server" Text='<%#Eval("tarihsaat") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </ItemTemplate>
            </asp:ListView>

        </div>

    </div>
</asp:Content>