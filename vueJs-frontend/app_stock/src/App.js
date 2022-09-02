import { globalMixin } from "./globalMixin/globalMixin";

export default {
    name: "app",
    mixins: [globalMixin],
    data() {
        return {
            name: "test"
           
        }
    },
    created() {

    }
};