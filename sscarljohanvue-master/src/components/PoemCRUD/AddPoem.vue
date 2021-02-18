<style>
#NewPoem {
    alignment: center;
    justify-content: center;
}
.row {
    display: flex;
    align-items: center;
    justify-content: center;
    height: 10vh;
}
</style>

<template>
    <div id="NewPoem">
        <h3>Ny dikt</h3>
        <div class="row">
            <form @submit.prevent="savePoem" class="NewPoem">
                <div class="row">
                    <div class="input-field col 12">
                        <input v-model="Rubrik" placeholder="Rubrik">
                    </div>
                </div>
                <div class="row">
                    <div class="input-field col 12">
                        <label>
                            <textarea v-model="PoemCont" placeholder="Diktens innehåll"></textarea>
                        </label>
                    </div>
                </div>
                <button type="submit" class="btn">Submit</button>
                <router-link to="/" class="btn_Cancel">Cancel</router-link>
            </form>
        </div>
    </div>
</template>
<script>
import db from "../firebaseInit";
export default {
    name: "new-poem",
    data() {
        return {
            Rubrik: null, //Set the content of Poem rubrik to null. Just to declare the variable? I think
            PoemCont: null
        };
    },
    methods: {
        savePoem() {
            db.collection("Poems")
                .add({
                    Rubrik: this.Rubrik, //This.Rubrik is bound to v-model ="rubrik"
                    PoemCont: this.PoemCont,
                    timestamp: new Date() //So, since i discovered firebase id functions if fucking worthless. I've added a timestamp instead.
                }) //fuck firebase. It also sets timestamp to date,and current time. UTC+1 with PM and AM of course. cuz fuck u that's why.
                .catch(onerror => console.log(onerror)); //If any errors occurs, show it in console window.
            this.$router.push("/");
        }
    }
};
</script>
