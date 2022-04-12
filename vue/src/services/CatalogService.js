import axios from "axios";

const baseUrl = "http://localhost:5001";
const http = axios.create({ baseURL: baseUrl });

export default {
  getExample(codeId) {
    return http.get(`/example/${codeId}`);
  },
  getQuery(query) {
    /* **FIX AFTER DAO/CONTROLLER IS IMPLEMENTED** */
    http.get(`/query/${query}`);
  },
  getKeywords() {
    // Will return all keywords resulting in a method on FE that will filter
    // based on specifics (language, code-statement, etc)
    http.get(`/keywords`);

    // TEMPORARY -- DELETE AFTER FIX
    return [
      {
        keyword: "language"
      },
      {
        keyword: "statement"
      }
    ];
  },
};
