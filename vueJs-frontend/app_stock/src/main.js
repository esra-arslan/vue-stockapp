import { createApp } from 'vue'
import App from './App.vue'
import addIndex from './views/stock/addIndex.vue'
import orderIndex from './views/stock/orderIndex.vue'
import hamper from './views/hamper.vue'
import router from './router'
import "bootstrap"
import { globalMixin } from "./globalMixin/globalMixin";
import $ from 'jquery'


import './assets/main.css'



createApp({
 
    extends: App,
    addIndex,
    orderIndex,
    hamper,
    mixins: [globalMixin],
    components: {
    }
   
}).use(router).mount('#app')

