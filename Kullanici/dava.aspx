<%@ Page Title="" Language="C#" MasterPageFile="~/AnaSayfaMasterPage.master" AutoEventWireup="true" CodeFile="dava.aspx.cs" Inherits="Kullanici_dava" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <title>Dava</title>
    <link href="/CssDosyalari/dava.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="Dava_div">
    <div class="bankaBilgiDiv">
        <table class="bankaBilgiTable" border="0">
            <tr>
                <td class="tg-midlee" colspan="2">
                    <asp:Label CssClass="label" runat="server">Yeni Dava</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Dava Türü: </td>
                <td class="tg-right">
                    <asp:DropDownList ID="drpDavaTuru" runat="server" CssClass="drplist" AutoPostBack="true" OnSelectedIndexChanged="drpDavaTuru_SelectedIndexChanged">
                        <asp:ListItem Text="Dava Türü"  Value="Dava Türü"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Dava No: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtDavaNo" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Açıklama: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtDavaAciklama" CssClass="TextBoxCssMulti" runat="server" TextMode="MultiLine" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Aktif: </td>
                <td class="tdright">
                    <asp:CheckBox ID="chckDavaAktif" runat="server" Checked="True"/>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Mahkeme: </td>
                <td class="tg-right">
                    <asp:DropDownList ID="drpMahkeme" runat="server" CssClass="drplist" AutoPostBack="true" OnSelectedIndexChanged="drpMahkeme_SelectedIndexChanged">
                        <asp:ListItem Text="Mahkeme"  Value="Mahkeme"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Taraf Türü: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtTarafTuru" runat="server"  ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Duruşma Tarihi: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtDurusmaTarihi"  runat="server" TextMode="Date" ></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="tg-left">Duruşma Açıklama: </td>
                <td class="tg-right">
                    <asp:TextBox ID="txtDurusmaAciklama" CssClass="TextBoxCssMulti" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tg-left">Duruşma Aktif mi: </td>
                <td class="tdright">
                    <asp:CheckBox ID="chckDurusmaAktif" runat="server" Checked="True"/>
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
                                    <b>Dava Türü: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblDavaTuru" runat="server" Text='<%#Eval("davaturu") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Dava No: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblDavaNo" runat="server" Text='<%#Eval("davano") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Açıklama: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblDavaAciklama" runat="server" Text='<%#Eval("davaaciklama") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Dava Aktif mi: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblDavaAktif" runat="server" Text='<%#Eval("davaaktif") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Mahkeme: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblMahkeme" runat="server" Text='<%#Eval("mahkeme") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Taraf Türü: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblTarafTuru" runat="server" Text='<%#Eval("tarafturu") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Duruşma Tarihi: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblDurusmaTarihi" runat="server" Text='<%#Eval("durusmaTarih") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Duruşma Hakkında: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lblDurusmaAciklama" runat="server" Text='<%#Eval("durusmaaciklama") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server">
                                <asp:TableCell CssClass="tblSol">
                                    <b>Duruşma Aktif mi: </b>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Label ID="lbldurusmaAktif" runat="server" Text='<%#Eval("durusmaaktif") %>'></asp:Label>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
               <%-- </ItemTemplate>
            </asp:ListView>--%>

        </div>

    </div>
</asp:Content>

