<template>
  <div>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
      <div class="container-fluid">
        <a class="navbar-brand" href="#">

          <a class="navbar-brand col-md-3 col-lg-2 me-0 px-3 fs-6" href="#">STOCK APP</a>
          <button class="navbar-toggler position-absolute d-md-none collapsed" type="button" data-bs-toggle="collapse"
            data-bs-target="#sidebauserMenu" aria-controls="sidebarMenu" aria-expanded="false"
            aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>

        </a>
        <div class="dgbutton">
          <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
            data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false"
            aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>
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
              <li class="nav-item">

              </li>
            </ul>
            <!-- Button trigger modal -->
            <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#myModal"
              v-show="!isLogin">
              <a class="nav-link px-3" href="#">{{ name }}</a>
            </button>
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
            <ul class="nav nav-pills mb-3" id="pills-tab" role="tablist">
              <li class="nav-item" role="presentation">
                <button class="nav-link active" id="singUp" data-bs-toggle="pill" data-bs-target="#pills-home"
                  type="button" role="tab" aria-controls="pills-home" aria-selected="true">
                  Giriş Yap
                </button>
              </li>
              <li class="nav-item" role="presentation">
                <button class="nav-link" id="pills-profile-tab" data-bs-toggle="pill" data-bs-target="#pills-profile"
                  type="button" role="tab" aria-controls="pills-profile" aria-selected="false">
                  Üye Ol
                </button>
              </li>
            </ul>
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
                <button type="submit" id="singup" class="btn btn-primary" value="" @click="login">
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
                    <input type="string" class="form-control" id="" aria-describedby="" />
                  </div>
                  <div class="mb-3">
                    <label for="surname" class="form-label">Soyad</label>
                    <input type="string" class="form-control" id="" aria-describedby="" />
                  </div>
                  <div class="mb-3">
                    <label for="surname" class="form-label">Cep Telefonu</label>
                    <input type="tel" class="form-control" id="phone" name="phone" placeholder="(5xx) xxx xx xx"
                      pattern="[0-9]{3}[0-9]{3}[0-9]{2}[0-9]{2}" required />
                  </div>

                  <div class="mb-3">
                    <label for="exampleInputEmail1" class="form-label">E-mail
                    </label>
                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" />
                  </div>

                  <div class="mb-3">
                    <label for="inputPassword5" class="form-label">Şifre</label>
                    <input type="password" id="pwd" name="pwd" class="form-control" minlength="8" />
                  </div>

                  <div class="mb-3">
                    <label for="inputPassword5" class="form-label">Şifre Tekrar</label>
                    <input type="password" id="pwd" name="pwd" class="form-control" minlength="8" />
                  </div>

                  <div class="mb-3 form-check">
                    <input type="checkbox" class="form-check-input" id="exampleCheck1" />
                    <label class="form-check-label" for="exampleCheck1">Beni Hatırla</label>
                  </div>

                  <button type="submit" class="btn btn-primary">
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
    <div class="container-fluid" :style="{'margin-left':sidebarWidth}">
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
      </div>
      <router-view />
    </div>
   
<div>
 
</div>
  </div>

</template>

<script src="./App.js"></script>

<style lang="scss">
@import'../node_modules/bootstrap/scss/bootstrap.scss';
</style>
