<template>

  <div id="parent">

    <div id="cloud-banner-div">
      <img
        class="cloud-banner"
        src="@/assets/cloudbanner3.svg"
        alt="CloudBanner"
      />
    </div>

    <div id="logo-div">
      <img
        class="logo"
        src="@/assets/cloudcodeFINALLL.svg"
        alt="CodeCatalog Logo"
        v-on:click.prevent="goHome"
      />
    </div>

    <div id="title">
      <h1>
      Code Out of Thin Air
    </h1>
    </div>

    <div id="site-desc">
      <h4>Welcome to Code Cloud - your one-stop-shop for all things code!</h4>
    </div>

    <div id="site-functions">
      <h5>Site Functions</h5>
      <ul>
        <li>Create an account</li>
        <li>Add Code</li>
        <li>Publish Code</li>
        <li>Explore Code</li>
        <li>Download Code</li>
      </ul>
    </div>

    <div id="MeetTeam">
      <h3>Meet The Team!</h3>
    </div> 

    <div id="team-row1">
      <div id="Misha">
        <h5>Misha Shatokhin</h5>
        <img
        class="misha-pic"
        src="@/assets/MS.jpg"
        alt="misha"
      />
      </div>
      <div id="aboutMisha">
        <ul>
          <li>After graduating, from THE Ohio State University with a BS in Finance, I began developing my Analytical and Leadership skills 
          in a corporate financial analyst role where I worked with the finances of 13 individual holding companies. This later turned 
          into a controllership role where I oversaw all financial decisions for 1 of the 13 holding companies all while continuing my 
          responsibilities as the sole corporate financial analyst. I gained a plethora of knowledge in the finance, accounting and data 
          departments and have decided to pivot into a coding career.</li>
          <li>I began my new career path by learning about coding from various online sources prior to enrolling as a student in the .NET/C# 
          coding bootcamp at Tech Elevator. After graduation I plan on looking for a junior developer role where I will build upon my current 
          knowledge in the coding industry. I will be searching for innovative organizations that have a strong desire to grow both 
          technically and culturally.</li>
        </ul>
      </div>
      <div id="Aidan">
        <h5>Aidan Wallace</h5>
        <img
        class="aidan-pic"
        src="@/assets/AW.jpg"
        alt="aidan"
      />
      </div>
      <div id="aboutAidan">
        <ul>
          <li>Starting as a self-taught programmer, I've learned many modern tools in JavaScript, Python, and C#. Before attending a coding 
          boot camp with Tech Elevator, I took Python classes offered by Columbus State.</li>
          <li>I started using my skills to learn tools around network security with Kali Linux, which gave me an idea of my own tools to make. 
          With my experience programming Raspberry Pi's, I applied my tools to a portable penetration testing tool.</li>
        </ul>
        </div>
    </div>

    <div id="team-row2">
      <div id="Jack">
        <h5>Jack Updyke</h5>
        <img
        class="jack-pic"
        src="@/assets/JA.jpg"
        alt="jack"
      />
      </div>
      <div id="aboutJack">
        <ul>
          <li>Hi, I’m Jack. I graduated from THE Ohio State University in 2018 with a bachelors in both Finance and Economics. During my time 
          at OSU, I always had a curiosity around software so I took a 1 year Data Analytics course where I had the opportunity to work on 
          2 semester long projects in a team setting and this experience pushed me into a career in software. Without the technical skills 
          to become a developer, my passion for software brought me to a career in Software Sales. After a few years spent in a Sales role 
          at various software companies, I decided it was time to shift my focus from selling software to building software applications. I 
          am currently a .NET bootcamp student at Tech Elevator with a desire to use my analytical skills as a foundation for a junior 
          developer role that allows me to collaborate with a team and continue to grow my coding skills.</li>
        </ul>
      </div>
      <div id="Patrick">
        <h5>Patrick Arace</h5>
        <img
        class="patrick-pic"
        src="@/assets/PA.jpg"
        alt="patrick"
      />
      </div>
      <div id="aboutPatrick">
        <ul>
          <li>Learning is my lifeblood. I have spent untold hours researching and discussing countless topics. Some of my favorites are music, 
          math, languages, and history. I have developed the view that the best mode in which to learn is to be willing to teach, and the 
          best mode in which to teach is to always be open to learning. I think this disposition is perfectly suited to a career in computing, 
          where change is the only constant.</li>
          <li>I knew I would end up in computing one day, but I took a few years out of my life to study humans first. I'm fascinated by the 
          symbiotic relationship that has emerged between humans and computers over the past 50 or so years, and feel that neither can be 
          properly understood without the other at this point. Equally, I feel that there are many clues about how we could compose the 
          future that lie undiscovered in the past.</li>
          <li>Some of my main interests in computing include: programming language design, functional languages, concurrent process modeling, 
          scheduling and coordination problems, robotic process automation, learning software, peer-to-peer networks and distributed systems 
          architectures, games and virtual worlds, personal cloud servers, and communications platforms.</li>
        </ul>
      </div>
    </div>
    <div id="cloud-footer-div">
      <img
        class="cloud-footer"
        src="@/assets/cloudbannerfooter.svg"
        alt="Cloudfooter"
      />
    </div>
    <!-- <catalog-example /> -->
    <!-- <download /> -->
  </div>

</template>

<script>
// import Download from '../components/Download.vue';
// import CatalogExample from "../components/CatalogExample.vue";
export default {
  name: "home",
  components: {
    // Download
    // CatalogExample,
  },
  created() {},
};
</script>

<style scoped>

#parent  {
  display: grid;
  grid-template-columns: auto;
  /* grid-template-rows: */
  grid-template-areas:
  "banner banner banner"
  "logo"
  "title"
  "site-desc"
  "site-func"
  "team1"
  "team2"
  "footer";
  row-gap: 7pt;
}
/* -------------------------------------------------------------------- */
#cloud-banner-div{
  grid-area:"banner";
  display:flex;

  align-items: center;
  justify-content: center;
}
#cloud-banner-div img{
  max-height: 100vw;
  background-repeat:repeat;
}
/* -------------------------------------------------------------------- */
#logo-div{
  grid-area: "logo";
  display: flex;

  align-items: center;
  justify-content: center;

  padding-top: 0pt;
  padding-bottom: 10pt;;
}
#logo-div img{
  border-radius: 5px;
  border-color: rgb(0, 150, 255);
  width: 55vh;
  box-shadow: 0 0 20px 3px rgb(0, 84, 147);
}
/* -------------------------------------------------------------------- */
#title{
  grid-area: "title";
  display: flex;

  align-items: center;
  justify-content: center;
}
#title h1{
font-weight: bold;
}
/* -------------------------------------------------------------------- */
#site-desc{
  grid-area: "site-desc";
  display: flex;

  align-items: center;
  justify-content: center;
}
/* -------------------------------------------------------------------- */
#site-functions{
  grid-area: "site-func";
  display: flex;
  flex-direction: column;

  align-items: center;
  justify-content: center;
}
#site-functions h5{
  font-weight: bold;
}
#site-functions li{
  font-style: italic;
}
/* -------------------------------------------------------------------- */
#MeetTeam{
  display: flex;
  align-items: center;
  justify-content: center;
  
}
#MeetTeam h3{
  font-weight: bold;
  text-decoration: underline;
  padding-top: 50pt;
}
/* -------------------------------------------------------------------- */
#team-row1{
  grid-area: "team1";
  display: flex;
  flex-direction: column;

  align-items: center;
  justify-content: center;
}
#team-row1 #Misha{
  display: flex;
  flex-direction: column;

  align-items: center;
  justify-content: center;
}
#team-row1 #Misha h5{
  font-weight: bold;
  font-style: italic;
}
#team-row1 #Misha img{
  width:25vh;
  padding-right: 20pt;
}
#team-row1 #aboutMisha{
  font-style:italic;
  max-width: 100%;
  padding-right: 50pt;
  padding-left: 50pt;
}
/* -------------------------- */
#team-row1 #Aidan{
  display: flex;
  flex-direction: column;

  align-items: center;
  justify-content: center;
}
#team-row1 #Aidan h5{
  font-weight: bold;
  font-style: italic;
}
#team-row1 #Aidan img{
  width:25vh;
  padding-right: 20pt;
}
#team-row1 #aboutAidan{
  font-style:italic;
  max-width: 100%;
  padding-right: 50pt;
  padding-left: 50pt;
}
/* -------------------------- */
#team-row2{
  grid-area: "team2";
  display: flex;
  flex-direction: column;

  align-items: center;
  justify-content: center;
}
#team-row2 #Jack{
  display: flex;
  flex-direction: column;

  align-items: center;
  justify-content: center;
}
#team-row2 #Jack h5{
  font-weight: bold;
  font-style: italic;
}
#team-row2 #Jack img{
  width:25vh;
  padding-right: 20pt;
}
#team-row2 #aboutJack{
  font-style:italic;
  max-width: 100%;
  padding-right: 50pt;
  padding-left: 50pt;
}
/* -------------------------- */
#team-row2 #Patrick{
  display: flex;
  flex-direction: column;

  align-items: center;
  justify-content: center;
}
#team-row2 #Patrick h5{
  font-weight: bold;
  font-style: italic;
}
#team-row2 #Patrick img{
  width:25vh;
  padding-right: 20pt;
}
#team-row2 #aboutPatrick{
  font-style:italic;
  max-width: 100%;
  padding-right: 50pt;
  padding-left: 50pt;
}
/* -------------------------- */
#cloud-footer-div{
  grid-area:"footer";
  display:flex;

  align-items: center;
  justify-content: center;
}
#cloud-footer-div img{
  max-height: 100vw;
  background-repeat:repeat;
}
</style>