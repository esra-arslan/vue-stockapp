
<template>
  <div>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
      <div class="container">
        <a class="navbar-brand" href="#">

          <a class="navbar-brand col-md-3 col-lg-2 me-0 px-3 fs-6 fw-bold" href="#">STOCK APP</a>
          <button class="navbar-toggler position-absolute d-md-none collapsed" type="button" data-bs-toggle="collapse"
            data-bs-target="#sidebauserMenu" aria-controls="sidebarMenu" aria-expanded="false"
            aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>
        </a>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav me-auto mb-2 mb-lg-0" v-show="isLogin">
            <li class="nav-item d-flex align-items-center">
              <router-link to="/" style="text-decoration:none;"><a class="nav-link active" aria-current="page"
                  href="#">Anasayfa</a></router-link>
              <span class="brace">|</span>
            </li>
            <li class="nav-item">
              <router-link to="/stock" style="text-decoration:none;"><a class="nav-link active" aria-current="page"
                  href="#">Stok Girişi</a></router-link>
            </li>
            <li class="nav-item">
              <router-link to="/order" style="text-decoration:none;"><a class="nav-link active" aria-current="page"
                  href="#">Sipariş Oluştur</a></router-link>
            </li>


          </ul>
        </div>
        <div class="dgbutton">
          <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav me-auto">
              <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" v-show="isLogin" href="#" id="navbarDropdown" role="button"
                  data-bs-toggle="dropdown" aria-expanded="false">
                  {{ name }}
                </a>
                <!-- dropdown button -->
                <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                  <li><a class="dropdown-item" href="#" @click="exit">Çıkış Yap</a></li>
                </ul>
              </li>
              <li class=" -item">

              </li>
            </ul>
            <!-- Button trigger modal -->
            <button type="button" class="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#myModal"
              v-show="!isLogin">
              <a class="nav-link px-3" href="#">{{ name }}</a>
            </button>
            &emsp;&emsp;
            <router-link to="/hamper">
            <button class="btn btn-warning"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16"
                fill="currentColor" class="bi bi-cart4" viewBox="0 0 16 16">
                <path
                  d="M0 2.5A.5.5 0 0 1 .5 2H2a.5.5 0 0 1 .485.379L2.89 4H14.5a.5.5 0 0 1 .485.621l-1.5 6A.5.5 0 0 1 13 11H4a.5.5 0 0 1-.485-.379L1.61 3H.5a.5.5 0 0 1-.5-.5zM3.14 5l.5 2H5V5H3.14zM6 5v2h2V5H6zm3 0v2h2V5H9zm3 0v2h1.36l.5-2H12zm1.11 3H12v2h.61l.5-2zM11 8H9v2h2V8zM8 8H6v2h2V8zM5 8H3.89l.5 2H5V8zm0 5a1 1 0 1 0 0 2 1 1 0 0 0 0-2zm-2 1a2 2 0 1 1 4 0 2 2 0 0 1-4 0zm9-1a1 1 0 1 0 0 2 1 1 0 0 0 0-2zm-2 1a2 2 0 1 1 4 0 2 2 0 0 1-4 0z" />
              </svg></button></router-link>
          </div>
        </div>
      </div>
    </nav>

    <!-- Modal -->
    <div class="modal fade" id="myModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">

            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" id="myBtn"></button>
          </div>
          <div class="modal-body">
            <div class="d-grid gap-2 d-md-flex justify-content-md">
              <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
                <li class="nav-item" role="presentation">
                  <button id="singUp" data-bs-toggle="pill" data-bs-target="#pills-home" type="button" role="tab"
                    aria-controls="pills-home" aria-selected="true" class="btn btn-warning ">
                    Giriş Yap
                  </button>
                </li>
                <li class="nav-item" role="presentation">
                  <button class="btn btn-outline-warning" id="pills-profile-tab" data-bs-toggle="pill"
                    data-bs-target="#pills-profile" type="button" role="tab" aria-controls="pills-profile"
                    aria-selected="false">
                    Üye Ol
                  </button>
                </li>
              </ul>
            </div>
            <div class="tab-content" id="pills-tabContent">
              <div class="tab-pane fade show active" id="pills-home" role="tabpanel" aria-labelledby="pills-home-tab"
                tabindex="0">
                <div class="mb-3">
                  <label for="exampleInputEmail1" class="form-label">E-mail
                  </label>
                  <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp"
                    v-model="user.email" />
                </div>
                <div class="mb-3">
                  <label for="inputPassword5" class="form-label">Şifreniz</label>
                  <input type="password" id="pwd" name="pwd" class="form-control" minlength="8"
                    v-model="user.password" />
                </div>

                <div class="mb-3 form-check">
                  <input type="checkbox" class="form-check-input" id="exampleCheck1" />
                  <label class="form-check-label" for="exampleCheck1">Beni Hatırla</label>
                </div>
                <!--  v-if='!user'  -->
                <button id="singup" class="btn btn-warning" value="" @click="login">
                  Giriş Yap
                </button>
                <!-- <button type="submit" id="singup" class="btn btn-primary" @click="getuser">get user</button> -->
              </div>

              <!-- Üye Ol-->

              <div class="tab-pane fade" id="pills-profile" role="tabpanel" aria-labelledby="pills-profile-tab"
                tabindex="0">
                <form>
                  <div class="mb-3">
                    <label for="name" class="form-label">Ad</label>
                    <input type="string" class="form-control" v-model="register.name" id="" aria-describedby=""
                      required />
                  </div>
                  <div class="mb-3">
                    <label for="surname" class="form-label">Soyad</label>
                    <input type="string" class="form-control" v-model="register.surname" id="" aria-describedby=""
                      required />
                  </div>
                  <div class="mb-3">
                    <label for="surname" class="form-label">Cep Telefonu</label>
                    <input type="tel" class="form-control" id="phone" name="phone" placeholder="(5xx) xxx xx xx"
                      pattern="[0-9]{3}[0-9]{3}[0-9]{2}[0-9]{2}" v-model="register.phoneNumber" required />
                  </div>

                  <div class="mb-3">
                    <label for="exampleInputEmail1" class="form-label">E-mail
                    </label>
                    <input type="email" class="form-control" id="exampleInputEmail1" v-model="register.email"
                      aria-describedby="emailHelp" required />
                  </div>

                  <div class="mb-3">
                    <label for="inputPassword5" class="form-label">Şifre</label>
                    <input type="password" id="pwd" name="pwd" class="form-control" v-model="register.password"
                      minlength="8" required />
                  </div>

                  <div class="mb-3">
                    <label for="inputPassword5" class="form-label">Şifre Tekrar</label>
                    <input type="password" id="pwd" name="pwd" class="form-control" v-model="register.password"
                      minlength="8" required />
                  </div>

                  <div class="mb-3 form-check">
                    <input type="checkbox" class="form-check-input" id="exampleCheck1" />
                    <label class="form-check-label" for="exampleCheck1">Beni Hatırla</label>
                  </div>

                  <button class="btn btn-warning" v-on:click="register_signup">
                    Üye Ol
                  </button>
                </form>

              </div>
            </div>
          </div>
        </div>
      </div>
    </div>


    <!-- sidebar menü -->
    <!-- v-show="isLogin" -->
    <!-- <div class="container-fluid" :style="{'margin-left':sidebarWidth}">
      <div class="row" >
        <nav id="sidebarMenu" class="col-md-3 col-lg-2 d-md-block bg-light sidebar collapse">
          <div class="position-sticky pt-3 sidebar-sticky">
            <ul class="nav flex-column">
               <li class="nav-item">
                <a class="nav-link" href="#">
                  <span data-feather="file" class="align-text-bottom"></span>
                
                 <router-link to="/"> Anasayfa</router-link>
                </a>
              </li>
              <br>
              <li class="nav-item">
                <a class="nav-link active" aria-current="page" href="#">
                  <span data-feather="home" class="align-text-bottom"></span>
                  <router-link to="/stock">Stok Girişi</router-link>
                </a>
              </li>
              <br>
              <li class="nav-item">
                <a class="nav-link" href="#">
                  <span data-feather="file" class="align-text-bottom"></span>
                  Stok Güncelle
                </a>
              </li>
              <br>
              <li class="nav-item">
                <a class="nav-link" href="#">
                  <span data-feather="shopping-cart" class="align-text-bottom"></span>
                  Stok Durumu
                </a>
              </li>
            </ul>
          </div>
        </nav>
       -->
    <router-view />
    <!-- <footer class="text-center text-white " style="background-color: #21081a;">
  <div class="container p-4"></div>

  <div class="text-center p-3" style="background-color: rgba(0, 0, 0, 0.2);">
   
    <a class="text-white" href=""></a>
  </div>
</footer>  -->
  </div>

</template>

<script src="./App.js"></script>  

<style lang="scss">
.brace {
  font-size: 20px;
  margin: 0px 20px;
  color: antiquewhite;
}

.nav-item a {
  color: #ffff;
  font-size: 16px;
  font-weight: bold;

}

@import'../node_modules/bootstrap/scss/bootstrap.scss';
</style>
