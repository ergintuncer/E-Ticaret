<%@ Page Title="" Language="C#" MasterPageFile="~/AnaSayfaMaster.master" AutoEventWireup="true" CodeFile="dava-turu.aspx.cs" Inherits="Kullanici_dava" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <title>Dava Türü</title>
    <link href="/CssDosyalari/davaTeur.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="pageDisDiv">
        <div class="ustDiv">
            <div class="lineOrta" style="border-bottom: solid silver thin; margin-bottom: 2%;">
                <asp:Label CssClass="label" runat="server" Text="Yeni Dava Türü" Font-Size="200%">Yeni Dava Türü Oluştur</asp:Label>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Dava Türü:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtDavaTur" CssClass="TexBoxCss" MaxLength="50" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Dava Aktif:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:CheckBox ID="chckDavaAktif" runat="server" Checked="True"/>
                </div>
            </div>
            <div class="line">
                <div class="lineSolDiv">
                    <asp:Label CssClass="label" runat="server">Açıklama:</asp:Label>
                </div>
                <div class="lineSagDiv">
                    <asp:TextBox ID="txtDavaAciklama" CssClass="TextBoxCssMulti" MaxLength="250" runat="server" TextMode="MultiLine"></asp:TextBox>

                </div>
            </div>
            <div class="line">
                <%--Bu divi Silme Duruşma Aktifmi Satırıını sola yaslamak için yapıldı--%>
            </div>
            <div class="lineOrta">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDavaTur" ErrorMessage="Dava Türü Giriniz" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDavaAciklama" ErrorMessage="Dava Türü Hakkında Açıklama Giriniz" SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" CssClass="validationSummary"/>
            </div>
            <div class="alert alert-success alert-dismissible fade show" role="alert" id="successalert" runat="server" Visible="False">
                Kayıt Ekleme işlemi başarı ile tamalandı.
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
            <div class="lineOrta">
                <button runat="server" id="btnKaydet" class="btn btn-outline-success" OnServerClick="btnKaydet_Click" Text="Kaydet">Kaydet </button>

            </div>

        </div>
        <div class="altDiv">
            <asp:ListView ID="list2" runat="server">
                <ItemTemplate>
                    <div class="ListeDiv">
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Dava Türü:</asp:Label>
                            </div>
                            <div class="lineSagDiv">

                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("davaturad") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Dava Aktif:</asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("aktif") %>'></asp:Label>

                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Dava Açıklama:</asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("aciklama") %>'></asp:Label>
                            </div>
                        </div>


                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Tarih:</asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblTarih" runat="server" Text='<%#Eval("tarihsaat") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <%--Bu divi Silme Duruşma Aktifmi Satırıını sola yaslamak için yapıldı--%>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>