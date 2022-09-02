<script>
import $ from "jquery"
import modal from "../../components/modal.vue"

export default {
    components: {
        modal
    },
    data() {
        return {
            count: 0,
            product: [{
                id: null,
                productCode: null,
                productName: null,
                stockNumber: null,
                purchasePrice: null,
                salePrice: null,
                kdv: null,
                imgurl: null
            }],
            productList: [],
            modall: null,


        }
    },
    methods: {
        showModal(id) {

            fetch(`https://localhost:7131/api/Product/GetProducts/` + id, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' }
            })
                .then(response => response.json())
                .then(data => this.product = data);
            this.modall = this.$refs.mProduct
            this.modall.show();


        },
        closeModal() {
            $("#myBtnn").trigger('click')
        },

        async save() {

            let self = this;
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    productCode: self.product.productCode,
                    productName: self.product.productName,
                    stockNumber: self.product.stockNumber,
                    purchasePrice: self.product.purchasePrice,
                    salePrice: self.product.salePrice,
                    kdv: self.product.kdv,
                    imgurl: self.product.imgurl
                })
            };

                fetch('https://localhost:7131/api/Product/AddProduct', requestOptions)
                    .then(response => response.json())
                    .then(data => element.innerHTML = data.id).catch(function (error) {
                        console.error(error);
                    })
        },
        async getProduct() {
            fetch("https://localhost:7131/api/Product/GetProducts")
                .then(response => response.json())
                .then(data => this.productList = data);
        },
        async deleteProduct(pId) {

            if (confirm("Silmek istediğinize emin misiniz?") == true) {
                fetch(`https://localhost:7131/api/Product/DeleteProduct/` + pId, {
                    method: 'DELETE',
                })
                    .then(res => res.json())
                    .then(res => console.log(res))
                window.location.reload()
            }
            else {

            }
        },
        async updateProduct(uId) {
            alert('test')
            let self = this;
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    productCode: self.product.productCode,
                    productName: self.product.productName,
                    stockNumber: self.product.stockNumber,
                    purchasePrice: self.product.purchasePrice,
                    salePrice: self.product.salePrice,
                    kdv: self.product.kdv,
                    imgurl: self.product.imgurl
                })
            };

                fetch('https://localhost:7131/api/Product/UpdateProduct' +uId, requestOptions)
                    .then(response => response.json())
                    .then(data => element.innerHTML = data.id).catch(function (error) {
                        console.error(error);
                    })
        }
    },


    mounted() {
        this.getProduct();
    }
};
</script>
<template>
    <div class="stock p-4">

        <div class="col-12">
            <div class="list-group ">

                <li class="list-group-item list-group-item-secondary">
                    <p class="fw-bolder "> STOK LİSTESİ
                        <button class="ekleB btn btn-secondary" @click="showModal">
                            Ürün Ekle
                            <i class="fa-solid fa-plus"></i>
                        </button>
                    </p>

                </li>
            </div>
            <div class="overflow-auto">
                <b-form-fieldset horizontal label="Filter" class="col-6">
                    <b-input v-model="filter" placeholder="Filter table.."></b-input>
                </b-form-fieldset>

                <b-table id="my-table" :filter="filter" :fields="fields" :items="items" small></b-table>
            </div>
            <table class="table table-hover table-bordered " id="example">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col" v-bind:href="product.imgurl"><strong>Ürün Resmi</strong></th>
                        <th scope="col"><strong> Ürün Kodu</strong></th>
                        <th scope="col"><strong>Ürün Adı</strong></th>
                        <th scope="col"><strong>Alış Fiyatı</strong></th>
                        <th scope="col"><strong>Satış Fiyatı</strong></th>
                        <th scope="col"><strong>KDV</strong></th>
                        <th scope="col"><strong>Stok Adedi</strong></th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="row in productList" :key="row.productCode">
                        <th scope="row">{{  row.id  }}</th>
                        <td> <img v-bind:src=row.imgurl height="90"></td>
                        <td>{{  row.productCode  }}</td>
                        <td>{{  row.productName  }}</td>
                        <td>{{  row.purchasePrice  }}</td>
                        <td>{{  row.salePrice  }}</td>
                        <td>{{  row.kdv  }}</td>
                        <td>{{  row.stockNumber  }}</td>
                        <td> <button type="button" class="btn btn-danger"><i class="fa-solid fa-trash-can"
                                    @click="deleteProduct(row.id)"></i>
                            </button>
                            &emsp;
                            <button class="btn btn-secondary" @click="showModal(row.id)">Güncelle</button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>


        <modal ref="mProduct">
            <form class="row g-3">
                <div class="mb-3 row mt-3">
                    <label for="validationCustom03" class="form-label col-sm-4">Ürün Kodu</label>
                    <div class="col-sm-8">
                        <input type="string" class="form-control " id="productCode" v-model="product.productCode"
                            required>
                        <div class="invalid-feedback">
                        </div>
                    </div>
                </div>
                <div class="mb-3 row mt-3">
                    <label for="validationCustom03" class="form-label col-sm-4">Ürün Adı</label>
                    <div class="col-sm-8">
                        <input type="string" class="form-control " id="productName" v-model="product.productName"
                            required>
                    </div>
                </div>
                <div class="mb-3 row mt-3">
                    <label for="validationCustom03" class="form-label col-sm-4">Ürün Resim URL</label>
                    <div class="col-sm-8 d-flex">
                        <input type="string" class="form-control" id="imgurl" v-model="product.imgurl" />

                        <button class=" btn btn-sm btn-danger" @click="product.imgurl = ''"><i
                                class="fa-solid fa-trash-can"></i></button>
                    </div>
                </div>
                <div class="mb-3 row mt-3" v-if="product.imgurl && product.imgurl.length > 10">
                    <div class="offset-4 col-sm-8">

                        <img v-bind:src=product.imgurl height="90" width="90">

                        <div class="invalid-feedback">
                        </div>
                    </div>
                </div>
                <div class="mb-3 row mt-3">
                    <label for="validationCustom03" class="form-label col-sm-4">Alış Fiyatı</label>
                    <div class="col-sm-8">
                        <input type="string" class="form-control" id="purchasePrice" v-model="product.purchasePrice">
                    </div>
                </div>
                <div class="mb-3 row mt-3">
                    <label for="validationCustom03" class="form-label col-sm-4">Satış Fiyatı</label>
                    <div class="col-sm-8">
                        <input type="string" class="form-control" id="salePrice" v-model="product.salePrice" required>
                    </div>
                </div>
                <div class="mb-3 row mt-3">
                    <label for="inputState" class="form-label col-sm-4">KDV</label>
                    <div class="col-sm-8">
                        <select id="kdv" class="form-select" v-model="product.kdv">
                            <option selected>%1</option>
                            <option>%8</option>
                            <option>%18</option>
                        </select>
                    </div>
                </div>
                <div class="mb-3 row mt-3">
                    <label for="validationCustom03" class="form-label col-sm-4">Stok Adedi</label>
                    <div class="col-sm-8">
                        <input type="string" class="form-control" id="stockNumber" v-model="product.stockNumber"
                            required>
                    </div>
                </div>

                <div class="btn-toolbar" role="toolbar" aria-label="Toolbar with button groups">
                    <div class="btn-group me-2 " role="group" aria-label="Third group">
                        <button class="saveB btn btn-success" @click="save" v-if="!product.id"><i
                                class="fas fa-check-circle"></i>
                            Kaydet </button>
                        <button class="saveB btn btn-warning " @click="updateProduct(product.id)" v-else><i
                                class="fas fa-check-circle"></i>
                            Güncelle </button>
                    </div>
                </div>
            </form>
        </modal>

    </div>
</template>

<style lang="scss">
.ekleB {
    position: absolute;
    right: 10px;
}

.saveB {
    position: absolute;
    left: 350px;
}
</style>
