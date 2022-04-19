import axios from "axios";

const baseUrl = "https://localhost:5001";
const http = axios.create({ baseURL: baseUrl });

export default {
  getExample(codeId) {
    return http.get(`/example/${codeId}`);
  },
  getExamples() {
    return http.get(`/example`);
  },
  getQuery(query) {
    /* **FIX AFTER DAO/CONTROLLER IS IMPLEMENTED** */
    return http.get(`example/search/${query}`);
  },
  addExample(newExample) {
    return http.post(`/example`, newExample);
  },
  fetchScript(codeId) {
    return http.get(`/script/${codeId}`);
  },
}