<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="baro.aspx.cs" Inherits="Admin_Baro" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <link href="/CssDosyalari/adminbaro.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="paylasimayar" id="paylasimayar">
        <div class="ustpanelyazidiv">
            <asp:Label CssClass="ustpanelyazi" runat="server"> Yeni Baro</asp:Label>
        </div>
        <div class="baro_divsol">
            <asp:Table ID="adliyetablosol" runat="server">
                <asp:TableRow ID="Label" class="kisiBilgitablerow" runat="server">
                    <asp:TableCell CssClass="tablecell">
                        <b>Baro Adı:</b>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tablecell">
                        <asp:TextBox ID="txtbaroadi" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow1" class="kisiBilgitablerow" runat="server">
                    <asp:TableCell CssClass="tablecell">
                        <b>Aktif: </b>
                    </asp:TableCell>
                    <asp:TableCell CssClass="tablecell">
                        <asp:CheckBox ID="CheckBox1" runat="server"/>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="TableRow2" class="navbuttonkaydetroww" runat="server">
                    <asp:TableCell CssClass="tablecell">
                    </asp:TableCell>
                    <asp:TableCell CssClass="navbuttonkaydetrow">
                        <button runat="server" id="bynBaroKaydet" onserverclick="btnKaydet_Onclick" class="buttonn" title="Baro Bilgisini Kaydet">
                            <i class="fa fa-floppy-o fa-2x"></i>Kaydet
                        </button>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>

    </div>

      <asp:ListView ID="list2" runat="server">
        <ItemTemplate>
    <div class="paylasimayar" id="paylasimayar">
        <div class="paylasimHeaderayar">
            <div class="ayarheadersol">
                <asp:Label ID="lblpaylasimHeaderAdi" CssClass="lblpaylasimHeaderAdi" runat="server"></asp:Label>
            </div>
            <div class="ayarheadersag">
               <%-- <button runat="server" id="aktiflik" onserverclick="Aktiflik_OnClick" class="fabutton" title="Aktif mi?">--%>
                    <a href="baro.aspx?islem=aktif&baroid=<%#Eval("baroid") %>"> <img src="/image/if_Tick_Mark_1398911.png" /> </a>
                   <%-- <i class="fa fa-check fa-2x"> </i>--%>
               <%-- </button>--%>

            </div>
        </div>

        <div class="paylasimIcerikayar">
            <div class="barosol">
                <asp:Table ID="kisibilgi" runat="server">
                    <asp:TableRow class="kisiBilgitablerow" runat="server">
                        <asp:TableCell>
                            <b>Baro Adı: </b>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblBaroAdi" runat="server" Text='<%#Eval("baroad") %>'></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>
            <div class="barosag">
                <asp:Table ID="adliyesag" runat="server">
                    <asp:TableRow class="kisiBilgitablerow" runat="server">
                        <asp:TableCell>
                            <b>Aktif: </b>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblAdktif" runat="server" Text='<%#Eval("aktif") %>'></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </div>


        </div>

    </div>

      </ItemTemplate>
    </asp:ListView>


</asp:Content>