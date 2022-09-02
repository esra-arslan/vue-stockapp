import { Alert } from "bootstrap";
import $ from "jquery"

export const globalMixin = {

    data() {
        return {
            count: 0,
            name: 'Giriş Yap',

            user: {
                id: 0,
                email: null,
                password: null,
                name: null
            },
            register: {

                name: null,
                surname: null,
                email: null,
                password: null,
                phoneNumber: null

            },
            isLogin: false
        }
    }, methods: {

        showModal() {

            var modal = document.getElementById("myModal");
            var btn = document.getElementById("myBtn");
            var span = document.getElementsByClassName("btn-close")[0];

            // modal.style.display = "block";

        },
        closeModal() {
            $("#myBtn").trigger('click')
        },
        async login() {
            let self = this;
            let res = await self.getData(`https://localhost:7131/api/User/Login?email=${self.user.email}&password=${self.user.password}`);
            if (res.result) {

                localStorage.setItem("user", JSON.stringify(self.user));
                this.name = self.user.email;
                self.closeModal();
                self.isLogin = true;

            } 
            else {
                alert('Email veya şifre hatalı, lütfen tekrar deneyiniz!');
                self.isLogin = false;
            }
            console.log(43, res);
        },

        async register_signup() {
            let self = this;

            //  alert("Name:"+self.register.name );


            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({

                    name: self.register.name,
                    surname: self.register.surname,
                    email: self.register.email,
                    password: self.register.password,
                    phoneNumber: self.register.phoneNumber,
                    role: 'customer'

                })
            };

            fetch('https://localhost:7131/api/User/Register', requestOptions)
                .then(response => response.json())
                .then(data => element.innerHTML = data.id).catch(function (error) {
                    console.error(error);
                })


        },

        async getData(pUrl, pApiUrl) {

            if (pApiUrl) {
                pUrl = pApiUrl + pUrl;
            }
            return new Promise((resolve, reject) => {
                try {
                    var myHeaders = new Headers({
                        "Content-Type": "text/json",
                    });
                    const myRequest = new Request(pUrl, {
                        method: "GET",
                        headers: myHeaders,
                        mode: "cors",
                        cache: "default",
                    });
                    fetch(myRequest)
                        .then((response) => response.json())
                        .then((responseData) => {
                            resolve(responseData);
                        });
                } catch (error) {

                    reject(error);
                }
            });
        },

        exit() {
            let self = this;
            localStorage.removeItem('user');

            self.isLogin = false;
            self.name = "Giriş Yap"

        }
    },

    async mounted() {
        let self = this;
        let data = JSON.parse(localStorage.getItem('user'));
        if (data != null) {
            self.isLogin = true;

            self.name = data.email;
        }
        else {
            self.isLogin = false;
        }
    }

};
