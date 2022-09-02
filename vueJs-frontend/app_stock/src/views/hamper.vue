<script >
export default {
  data() {
    return {
      count: 0,
      hamper: [{
        id: null,
        productName: null,
        number: null,
        price: null,
        totalPrice: null,
        imgurl: null
      }],
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
    }
  },
}
</script>
<template>
  <div class="stock p-4">
    <div class="col-12">
      <div class="list-group ">

        <li class="list-group-item list-group-item-secondary">
          <p class="fw-bolder"> SEPETİM</p>
          
          <span class="counter pull-right"></span>

        </li>
      </div>
      <table class="table table-hover table-bordered results" id="example">
        <thead>
          <tr>
            <th scope="col">#</th>
            <th scope="col" v-bind:href="product.imgurl"><strong>Ürün Resmi</strong></th>
            <th scope="col"><strong> Ürün</strong></th>
            <th scope="col"><strong> Fiyatı</strong></th>
            <th scope="col"><strong>Adet</strong></th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="row in productList" :key="row.productCode">
            <td></td>
            <td> <img v-bind:src=row.imgurl height="90"></td>
            <td>{{  row.productName  }}</td>
            <td>{{  row.price  }}</td>
            <td>{{  row.number  }}</td>
            <td> <button type="button" class="btn btn-danger"><i class="fa-solid fa-trash-can"
                  @click="deleteProduct(row.id)"></i>
              </button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>

</template>

<style lang="scss">
</style>