<%@ Page Title="Para İşlemleri" Language="C#" MasterPageFile="~/AnaSayfaMaster.master" AutoEventWireup="true" CodeFile="para-hareket.aspx.cs" Inherits="Kullanici_para_hareket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pageDisDiv">
        <div class="ustDiv">
            <asp:ScriptManager ID="MainScriptManager" runat="server"/>
            <asp:UpdatePanel ID="pnlHelloWorld" runat="server">
                <ContentTemplate>
                    <div class="lineOrta" style="border-bottom: solid silver thin; margin-bottom: 2%;">
                        <asp:Label CssClass="label" runat="server" Text="Para Hareket Bilgisi" Font-Size="200%">Para Hareket Bilgisi</asp:Label>
                    </div>
                    <div class="line">
                        <div class="lineSolDiv">
                            <asp:Label CssClass="label" runat="server">İşlem Türü:</asp:Label>
                        </div>
                        <div class="lineSagDiv">
                            <asp:Label CssClass="label" runat="server">Kişiden Kişiye:</asp:Label>
                            <%-- <asp:DropDownList ID="drpIslemTuru" runat="server" CssClass="drplist" AutoPostBack="False" OnSelectedIndexChanged="drpIslemTuru_SelectedIndexChanged">
                        <asp:ListItem Text="Kişiden Kişiye" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Kişiden Banka Hesabına" Value="1"></asp:ListItem>
                    </asp:DropDownList>--%>
                        </div>
                    </div>
                    <div class="line">
                        <div class="lineSolDiv">
                            <asp:Label CssClass="label" runat="server">Gönderen:</asp:Label>
                        </div>
                        <div class="lineSagDiv">
                            <asp:DropDownList ID="drpGonderen" runat="server" CssClass="drplist" AutoPostBack="False" OnSelectedIndexChanged="drpGonderen_SelectedIndexChanged">

                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="line">
                        <div class="lineSolDiv">
                            <asp:Label CssClass="label" runat="server">Makbuz No:</asp:Label>
                        </div>
                        <div class="lineSagDiv">
                            <asp:TextBox ID="txtMakbuzNo" CssClass="TexBoxCss" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="line">
                        <div class="lineSolDiv">
                            <asp:Label CssClass="label" runat="server">Alıcı:</asp:Label>
                        </div>
                        <div class="lineSagDiv">
                            <asp:DropDownList ID="drpAlici" runat="server" CssClass="drplist" AutoPostBack="False" OnSelectedIndexChanged="drpAlici_SelectedIndexChanged">

                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="line">
                        <div class="lineSolDiv">
                            <asp:Label CssClass="label" runat="server">Tarih Saat:</asp:Label>
                        </div>
                        <div class="lineSagDiv">
                            <asp:TextBox ID="txtTarihSaat" CssClass="TexBoxCss" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="line">
                        <div class="lineSolDiv">
                            <asp:Label CssClass="label" runat="server">Tutar:</asp:Label>
                        </div>
                        <div class="lineSagDiv">
                            <asp:TextBox ID="txtTutar" CssClass="TexBoxCss" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="line">
                        <div class="lineSolDiv">
                            <asp:Label CssClass="label" runat="server">Açıklama:</asp:Label>
                        </div>
                        <div class="lineSagDiv">
                            <asp:TextBox ID="txtAciklama" CssClass="TextBoxCssMulti" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <div class="line">
                        <%-- Bu divi Silme --%>
                    </div>
                    <div class="lineOrta">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTarihSaat" ErrorMessage="Lütfen Tarihi Kontrol Ediniz..." SetFocusOnError="True" Display="None"></asp:RequiredFieldValidator>

                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" CssClass="validationSummary"/>
                    </div>
                    <div class="lineOrta">
                        <button runat="server" id="btnKaydet" class="button" OnServerClick="btnKaydet_Click" Text="Kaydet">
                            <i class="fa fa-save fa-2x"></i>Kaydet
                        </button>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


        <div class="altDiv">
            <asp:ListView ID="list2" runat="server">
                <ItemTemplate>
                    <div class="ListeDiv">
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Makbuz No: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblilce" runat="server" Text='<%#Eval("makbuzno") %>'></asp:Label>

                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Gönderen: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lbladresadi" runat="server" Text='<%#Eval("gonderen") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Alıcı: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lbladres" runat="server" Text='<%#Eval("alici") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Tutar: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblaciklama" runat="server" Text='<%#Eval("tutar") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Tarih: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("harekettarihsaat") %>'></asp:Label>
                            </div>
                        </div>
                        <div class="line">
                            <div class="lineSolDiv">
                                <asp:Label CssClass="label" runat="server">Açıklama: </asp:Label>
                            </div>
                            <div class="lineSagDiv">
                                <asp:Label ID="lblaktif" runat="server" Text='<%#Eval("aciklama") %>'></asp:Label>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>

        </div>

    </div>

</asp:Content>