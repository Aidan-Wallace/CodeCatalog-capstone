import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";

Vue.use(Vuex);

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem("token");
const currentUser = JSON.parse(localStorage.getItem("user"));

if (currentToken != null) {
  axios.defaults.headers.common["Authorization"] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || "",
    user: currentUser || {},
    getNewExample: {
      title: "",
      programmingLanguage: "",
      codeDescription: "",
      category: "",
      codeSnippet: "",
      difficultyRank: "",
      attribution: "",
    },
    getCategories: [
      "algorithms",
      "artificial",
      "data",
      "databases",
      "functional",
      "mathematics",
      "web",
      "other",
    ],
    availableLanguages: [
      "Bash",
      "C",
      "C#",
      "C++",
      "Clojure",
      "Common Lisp",
      "CSS",
      "Diff",
      "Elixir",
      "Erlang",
      "F#",
      "Go",
      "Haskell",
      "HTML, XML",
      "JSON",
      "Java",
      "JavaScript",
      "Kotlin",
      "Less",
      "Lua",
      "Makefile",
      "Markdown",
      "Objective-C",
      "PHP",
      "PHP Template",
      "Perl",
      "Plain text",
      "Python",
      "Python REPL",
      "R",
      "Ruby",
      "Rust",
      "SCSS",
      "SQL",
      "Scheme",
      "Shell Session",
      "Smalltalk",
      "Swift",
      "TOML",
      "TypeScript",
      "Visual Basic.NET",
      "Wolframlang",
    ],
  },

  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem("token", token);
      axios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem("user", JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem("token");
      localStorage.removeItem("user");
      state.token = "";
      state.user = {};
      axios.defaults.headers.common = {};
    },
    SET_CURRENT_EXAMPLE(context, payload) {
      context.currentExample = payload;
    },
  },
});
