<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="kisiler.aspx.cs" Inherits="Admin_kisiler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <title>Admin Kişiler</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ListView ID="list2" runat="server">
        <ItemTemplate>
            <div class="paylasimayar" id="paylasimayar">
                <div class="paylasimHeaderayar">
                    <div class="ayarheadersol">
                        <asp:Label ID="lblpaylasimHeaderAdi" CssClass="lblpaylasimHeaderAdi" runat="server" Text="Ad Soyad"></asp:Label>
                    </div>
                    <div class="ayarheadersag">
                        <button runat="server" id="kabulEt" onserverclick="KullaniciSil_OnClick" class="kabulEt" title="Onayla">
                            <i class="fa fa-check fa-2x"> </i>
                        </button>
                        <button runat="server" id="reddet" onserverclick="KullaniciOnayla_OnClick" class="reddet" title="Sil">
                            <i class="fa fa-trash fa-2x"> </i>
                        </button>
                    </div>
                </div>

                <div class="paylasimIcerikayar">
                    <asp:Table ID="kisibilgi" runat="server">
                        <asp:TableRow ID="Label" class="kisiBilgitablerow" runat="server">
                            <asp:TableCell>
                                <b>Kimlik Numarası:</b>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="TcKimlikNo" CssClass="kisiBilgi" runat="server" Text='<%#Eval("tck") %>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow ID="TableRow1" class="kisiBilgitablerow" runat="server">
                            <asp:TableCell>
                                <b>Firma Bilgisi :</b>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="firma" CssClass="kisiBilgi" runat="server" Text='<%#Eval("firma") %>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow ID="TableRow2" class="kisiBilgitablerow" runat="server">
                            <asp:TableCell>
                                <b>Baro Bilgisi:</b>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="baroBilgi" CssClass="kisiBilgi" runat="server" Text=" "></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow ID="TableRow3" class="kisiBilgitablerow" runat="server">
                            <asp:TableCell>
                                <b> Numarası: </b>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="sicilNo" CssClass="kisiBilgi" runat="server" Text='<%#Eval("sicilno") %>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow ID="TableRow4" class="kisiBilgitablerow" runat="server">
                            <asp:TableCell>
                                <b>Birlik Sicil Numarası: </b>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="birlikSicilNumarası" CssClass="kisiBilgi" runat="server" Text='<%#Eval("birliksicilno") %>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>

                </div>

            </div>

        </ItemTemplate>
    </asp:ListView>
</asp:Content>