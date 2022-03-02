<template>
    <div class="container">

        <h1>Products</h1>
        
        <form class="d-flex my-4 col-6" v-on:submit.prevent="noop">
            <input class="form-control" @change="searchProducts" v-model="search" type="search" placeholder="Search" aria-label="Search">
        </form>
        

        <p v-if="!products"><em>Loading...</em></p>



        <div v-if="products">
            <div class="row">
                <div class="col-4" v-for="product in products" v-bind:key="product">
                    <div class="card" style="width: 18rem;">
                        <img class="card-img-top" :src="product.imageUrl" alt="Card image cap">
                        <div class="card-body">
                            <h5 class="card-title">{{product.productName}}</h5>
                        </div>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">Стара цена: {{product?.price}}</li>
                            <li class="list-group-item">Намелена цена: {{product?.discountPrice}}</li>
                            <li class="list-group-item">Намаление: {{product?.discount}}</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

    </div>
</template>


<script>
    import axios from 'axios'
    export default {
        name: "FetchData",
        data() {
            return {
                products: [],
                search: ''
            }
        },
        methods: {
            getProducts() {
                axios.get('/product')
                    .then((response) => {
                        this.products =  response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            searchProducts() {
                console.log(this.search);
                axios.get(`/product?search=${this.search}`)
                    .then((response) => {
                        console.log('Called');
                        this.products = response.data;
                    })
                    .catch(function (error) {
                        alert(error);
                    });
            },
            noop() {
                // do nothing 
            }
        },
        mounted() {
            this.getProducts();
        }
    }
</script>