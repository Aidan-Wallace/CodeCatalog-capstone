import axios from "axios";

const baseUrl = "https://localhost:5001";
const http = axios.create({ baseURL: baseUrl });

export default {
  getExample(codeId) {
    return http.get(`/example/${codeId}`);
  },
  getExamples() {
    return http.get(`/example/status/1`);
  },
<<<<<<< HEAD
  getGenericExamples(){
=======
  getGenericExamples() {
>>>>>>> 8b085253317bb49f44fe4fa4e540e9afa4da2599
    return http.get(`/example/set-list`);
  },
  getQuery(query) {
    /* **FIX AFTER DAO/CONTROLLER IS IMPLEMENTED** */
    return http.get(`example/search/${query}`);
  },
  addExample(newExample, userId) {
    return http.post(`/example/${userId}`, newExample);
  },
  fetchScript(codeId) {
    return http.get(`/script/${codeId}`);
  },
}