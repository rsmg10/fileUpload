<script setup lang="ts">
import axios from "axios";
const handleUploadImage = async (event: Event) => {
  if ((event.target as HTMLInputElement).files) {
    const files = (event.target as HTMLInputElement).files as FileList;
    const file = files.length > 0 ? files[0] : null;

    if (!file) return;

    console.log(file);

    const formData = new FormData();

    formData.append("file", file as Blob);

    const { data } = await axios.post(
      "http://localhost:5218/UploadAllFile",
      formData,
      {
        // onUploadProgress: (progressEvent) => console.log(progressEvent.loaded),
        headers: {
          Accept: "*/*",
          "Content-Type": "multipart/form-data",
        },
      }
    );

    console.log(data);
  }
};
</script>

<template>
  <div>
    <label for="file" class="image-button">Upload Image</label>

    <input
      id="file"
      name="file"
      type="file"
      accept="image/*"
      class="hidden"
      @change="handleUploadImage"
    />

    <!-- <a href="https://vitejs.dev" target="_blank">
      <img src="/vite.svg" class="logo" alt="Vite logo" />
    </a>
    <a href="https://vuejs.org/" target="_blank">
      <img src="./assets/vue.svg" class="logo vue" alt="Vue logo" />
    </a> -->
  </div>
  <!-- <HelloWorld msg="Vite + Vue" /> -->
</template>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}

.hidden {
  display: none;
}

.image-button {
  background-color: azure;
  padding: 12px 24px;
  text-align: center;
  color: cadetblue;
  font-weight: bold;
  font-size: 24px;
  border-radius: 8px;
}
</style>
