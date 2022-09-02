<script >

export default {
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
      hamper: []

    }
  },
  methods: {
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

    async addHamper(pItem) {
      this.hamper.push(pItem);
    },
   
  },
  mounted() {
    this.getProduct();
  }
}

</script>

<template>
  <div class="stock p-4">
    <div class="col-12">
      <div class="list-group ">

        <li class="list-group-item list-group-item-secondary">
          <p class="fw-bolder"> ÜRÜN LİSTESİ</p>
          <div class="form-group pull-right">
            <input type="text" class="search form-control" placeholder="Ne aramıştınız?">
          </div>
          <span class="counter pull-right"></span>

        </li>
      </div>
      <table class="table table-hover table-bordered results" id="hamperTable">
        <thead>
          <th scope="col" v-bind:href="product.imgurl"></th>
        </thead>

        <tbody class="">
          <tr v-for="row in productList" :key="row.productCode">
            <div class="row">
              <div class="col-2">
                <td> <img v-bind:src=row.imgurl height="90">

                <th><strong> {{ row.productCode }} </strong></th>
                </td>
              </div>
              <div class="col-3">
                <div id="productName"></div>
                <td><strong>{{ row.productName }}</strong></td>
          <tr>(Kilo Fiyatıdır)</tr>
          <tr><strong>{{ row.salePrice }}₺</strong></tr>
          <td>
            <!-- <router-link to="/hamper"></router-link> -->
            <button id="basket" class="btn btn-warning" @click="addHamper">Sepete Ekle</button>

          </td>
    </div>
  </div>
  </tr>
  </tbody>

  </table>

  </div>
  </div>
</template>


<style scoped>
</style>
