<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="mahkeme.aspx.cs" Inherits="Admin_Mahkeme" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <link href="/CssDosyalari/adminmahkeme.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="paylasimayar" id="paylasimayar">
        <asp:Label CssClass="ustpanelyazi" runat="server"> Yeni Mahkeme </asp:Label>
        <div class="ortaAlan">
            
        
        <div class="adliyesol">
            <asp:Table ID="adliyetablosol" runat="server">
                <asp:TableRow ID="Label" class="kisiBilgitablerow" runat="server">
                    <asp:TableCell>
                        <b>Mahkeme Adı: </b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtMahkemeAdi" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow1" class="kisiBilgitablerow" runat="server">
                    <asp:TableCell>
                        <b>Adliye: </b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList ID="drpAdliye" runat="server"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <div class="adliyesag">
            <asp:Table ID="adliyesag" runat="server">
                <asp:TableRow ID="TableRow4" class="navbuttonkaydetroww" runat="server">
                    <asp:TableCell>
                        <b>Aktif: </b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:CheckBox ID="ctxAktif" runat="server"/>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow ID="TableRow5"  runat="server">
                    <asp:TableCell CssClass="navbuttonkaydetroww">
                        <b>Mahkeme Türü: </b>
                    </asp:TableCell>
                    <asp:TableCell >
                        <asp:DropDownList ID="drpMahkemeTuru" runat="server"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow7" runat="server">
                    <asp:TableCell>
                    </asp:TableCell>
                    <asp:TableCell CssClass="navbuttonkaydetrow">
                        <button runat="server" id="btnKaydet" onserverclick="btnKaydet_Onclick" class="buttonn" title="Adliye Bilgisini Kaydet">
                            <i class="fa fa-floppy-o fa-2x"></i>Kaydet
                        </button>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div></div>
    </div>

    <%--  <asp:ListView ID="list2" runat="server">
        <ItemTemplate>--%>
    <div class="paylasimayar" id="paylasimayar">
        <div class="paylasimHeaderayar">
            <div class="ayarheadersol">
                <asp:Label ID="lblpaylasimHeaderAdi" CssClass="lblpaylasimHeaderAdi" runat="server"></asp:Label>
            </div>
            <div class="ayarheadersag">
                <button runat="server" id="aktiflik" onserverclick="Aktiflik_OnClick" class="fabutton" title="Aktif mi?">
                    <i class="fa fa-check fa-2x"> </i>
                </button>
            </div>
        </div>

        <div class="paylasimIcerikayar">
            <asp:Table ID="kisibilgi" runat="server">
                <asp:TableRow class="kisiBilgitablerow" runat="server">
                    <asp:TableCell>
                        <b>Mahkeme Adı: </b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblMahkemeAdi" CssClass="il" runat="server" Text='<%#Eval("mahkemeadi") %>'></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow class="kisiBilgitablerow" runat="server">
                    <asp:TableCell>
                        <b>Adliye: </b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblAdliye" runat="server" Text='<%#Eval("adliyeadi") %>'></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow class="kisiBilgitablerow" runat="server">
                    <asp:TableCell>
                        <b>Aktif mi: </b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblaktif" CssClass="lblaktif" runat="server" Text='<%#Eval("aktif") %>'></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow class="kisiBilgitablerow" runat="server">
                    <asp:TableCell>
                        <b>Mahkeme Türü: </b>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblMahkemeTuru" runat="server" Text='<%#Eval("mahkemeturu") %>'></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

            </asp:Table>
        </div>

    </div>

    <%--  </ItemTemplate>
    </asp:ListView>--%>


</asp:Content>