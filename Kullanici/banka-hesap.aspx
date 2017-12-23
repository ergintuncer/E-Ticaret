<%@ Page Title="Banka Hesap işlemleri" Language="C#" MasterPageFile="~/AnaSayfaMaster.master" AutoEventWireup="true" CodeFile="banka-hesap.aspx.cs" Inherits="Kullanici_banka_hesap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <link href="/CssDosyalari/bankaHesapp.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pageDisDiv">
        <div class="ustDiv">
           
            <div class="lineOrta" style="border-bottom: solid silver thin; margin-bottom: 2%;">
                <asp:Label CssClass="label" runat="server" Text="Yeni Banka Hesabı Oluştur" Font-Size="200%">Yeni Banka Hesabı Oluştur</asp:Label>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Banka:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpBanka" runat="server" CssClass="drplist" AutoPostBack="true" OnSelectedIndexChanged="drpBanka_SelectedIndexChanged">
                        <%--<asp:ListItem Text="Banka" Value="Banka"></asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Hesap Türü:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpHesapTuru" runat="server" CssClass="drplist" AutoPostBack="true" OnSelectedIndexChanged="drpHesapTuru_SelectedIndexChanged">
                       <%-- <asp:ListItem Text="Hesap Türü" Value="Hesap Türü"></asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Bakiye Türü:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:DropDownList ID="drpBakiyeTur" runat="server" CssClass="drplist" AutoPostBack="true" OnSelectedIndexChanged="drpBakiyeTur_SelectedIndexChanged">
                        <%--<asp:ListItem Text="Bakiye Türü" Value="Bakiye Türü"></asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Hesap Adı:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtHesapAdi" CssClass="TexBoxCss" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Hesap No:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtHesapNo" CssClass="TexBoxCss" runat="server" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">IBAN No:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtIbanNo" CssClass="TexBoxCss" runat="server" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Bakiye:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtBakiye" CssClass="TexBoxCss" runat="server" TextMode="Number"></asp:TextBox>
                </div>
            </div>

            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Hesap Aktif:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:CheckBox ID="chckHesapAktif" runat="server" Checked="True"/>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Açıklama:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtHesapAciklama" CssClass="TextBoxCssMulti" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="line">
                <%-- Bu divi silme. Ortalama yapması için konuldu--%>
            </div>
            <div class="lineOrta">
                <button runat="server" id="btnKaydet" class="btn btn-outline-success" OnServerClick="btnKaydet_Click" Text="Kaydet">Kaydet </button>
            
            </div>
            
            <div class="alert alert-success alert-dismissible fade show" role="alert" id="successalert" runat="server" Visible="False">
               
                <asp:Label ID="lblacik" CssClass="label" runat="server" Font-Bold="True"> Değişiklik Gerçekleştirildi... </asp:Label>

                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="alert alert-danger alert-dismissible fade show" role="alert" id="dangeralert" runat="server" Visible="False">
                Hay aksi. Bir hata oluştu.
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>


        </div>


        <div class="altDiv">
        <asp:ListView ID="list2" runat="server">
                <ItemTemplate>
            <div class="ListeDiv">
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label CssClass="label" runat="server">Hesap Adı: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="lblBanka" runat="server" Text='<%#Eval("bankahesapad") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label CssClass="label" runat="server">Banka Adı: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="lblHesapTuru" runat="server" Text='<%#Eval("bankaad") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label CssClass="label" runat="server">Hesap Türü: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="lblBakiyeTur" runat="server" Text='<%#Eval("bankahesapturad") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label CssClass="label" runat="server">Bakiye Türü: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="lblHesapAdi" runat="server" Text='<%#Eval("bakiyeturad") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label CssClass="label" runat="server">HEsap No: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="lblHesapNo" runat="server" Text='<%#Eval("bankahesapno") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label CssClass="label" runat="server">IBAN No: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="lblIban" runat="server" Text='<%#Eval("bankahesapiban") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label CssClass="label" runat="server">Bakiye Bilgisi: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="lblHesapBakiye" runat="server" Text='<%#Eval("hesapbakiye") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label CssClass="label" runat="server">Aktif: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="lblAktif" runat="server" Text='<%#Eval("aktif") %>'></asp:Label>
                    </div>
                </div>
                <div class="line">
                    <div class="lineSolDiv">
                        <asp:Label CssClass="label" runat="server">Açıklama: </asp:Label>
                    </div>
                    <div class="lineSagDiv">
                        <asp:Label ID="lblAciklama" runat="server" Text='<%#Eval("aciklama") %>'></asp:Label>
                    </div>
                </div>
               
                       
                       
                <div class="lineOrtaSol">
                    <a href="banka-hesap.aspx?islem=bloke&kisiid=<%#Eval("bankahesapid") %>"> <img src="/image/cancel.png"/></a>
                </div>
            </div>
            </div>
                    

         </ItemTemplate>
      </asp:ListView>
        </div>
    </div>


</asp:Content>