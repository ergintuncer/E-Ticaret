<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adliye.aspx.cs" Inherits="Admin_Adliye" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <link href="/CssDosyalari/adminadliye.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="paylasimayar" id="paylasimayar">
        <asp:Label CssClass="ustpanelyazi" runat="server"> Yeni Adliye </asp:Label>
        <div class="adliyesol">
            <asp:Table ID="adliyetablosol" runat="server">
     <asp:TableRow ID="Label" class="kisiBilgitablerow" runat="server">
                    <asp:TableCell>
                        <b>Adliye Adı:</b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtadliyeadi" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow1" class="kisiBilgitablerow" runat="server">
                    <asp:TableCell>
                        <b>İl :</b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="drpil" runat="server"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow2" class="kisiBilgitablerow" runat="server">
                    <asp:TableCell>
                        <b>Adres adı:</b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtadresadi" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow3" class="kisiBilgitablerow" runat="server">
                    <asp:TableCell>
                        <b>Açıklama:</b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtaciklama" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

            </asp:Table>
        </div>
        <div class="adliyesag">
            <asp:Table ID="adliyesag" runat="server">
                <asp:TableRow ID="TableRow4" class="kisiBilgitablerow" runat="server">
                    <asp:TableCell>
                        <b>Aktif:</b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="ctxAktif" runat="server" Text="Aktif"/>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow5" class="kisiBilgitablerow" runat="server">
                    <asp:TableCell>
                        <b>İlçe:</b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="drpilce" runat="server"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow6" class="kisiBilgitablerow" runat="server">
                    <asp:TableCell>
                        <b>Adres:</b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtadres" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow7" runat="server">
                    <asp:TableCell>
                    </asp:TableCell>
                    <asp:TableCell CssClass="navbuttonkaydetrow">
                        <button runat="server" id="btnKaydet" onserverclick="btnKaydet_Onclick" class="button" title="Adliye Bilgisini Kaydet">
                            <i class="fa fa-floppy-o fa-2x"></i>Kaydet
                        </button>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>

  <%--  <asp:ListView ID="list2" runat="server">
        <ItemTemplate>--%>
            <div class="paylasimayar" id="paylasimayar">
                <div class="paylasimHeaderayar">
                    <div class="ayarheadersol">
                        <asp:Label ID="lblpaylasimHeaderAdi" CssClass="lblpaylasimHeaderAdi" runat="server" Text="Adliye Adı"></asp:Label>
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
                                <b>İl: </b>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lblil" CssClass="il" runat="server" Text='<%#Eval("il") %>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow  class="kisiBilgitablerow" runat="server">
                            <asp:TableCell>
                                <b>İlçe: </b>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lblilce" CssClass="lblilce" runat="server" Text='<%#Eval("ilce") %>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow  class="kisiBilgitablerow" runat="server">
                            <asp:TableCell>
                                <b>Adres Adı: </b>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lbladresadi" CssClass="lbladresadi" runat="server" Text='<%#Eval("adresadi") %>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow  class="kisiBilgitablerow" runat="server">
                            <asp:TableCell>
                                <b>Adres: </b>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lbladres" CssClass="lbladres" runat="server" Text='<%#Eval("adres") %>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>

                        <asp:TableRow  class="kisiBilgitablerow" runat="server">
                            <asp:TableCell>
                                <b>Açıklama: </b>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lblaciklama" CssClass="lblaciklama" runat="server" Text='<%#Eval("aciklama") %>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow  class="kisiBilgitablerow" runat="server">
                            <asp:TableCell>
                                <b>Aktif mi: </b>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lblaktif" CssClass="lblaktif" runat="server" Text='<%#Eval("aktif") %>'></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>

            </div>

      <%--  </ItemTemplate>
    </asp:ListView>--%>


</asp:Content>