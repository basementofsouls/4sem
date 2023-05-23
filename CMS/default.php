<?php defined('_JEXEC') or die; ?>
<html>
  <head>
   <style>
    .contact-container {
    position: relative;
    width: 300px;
  }
  
  .contact-btn {
    background-color: #007bff;
    color: #fff;
    border: none;
    padding: 10px;
    border-radius: 5px;
    cursor: pointer;
    width: 100%;
    transition: all 0.3s ease-in-out;
  }
  
  .contact-form-container {
    position: top;
    top: 100%;
    left: 0;
    width: 100%;
    padding: 10px;
    border: 1px solid #007bff;
    border-radius: 5px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
    background-color: #fff;
    display: none;
  }
  
  .contact-form-container.active {
    display: block;
  }
  .send_but{
    background-color: pink;
    color: #fff;
    border: none;
    padding: 10px;
    margin-top: 25px;
    border-radius: 5px;
    cursor: pointer;
    text-align:center;
    transition: all 0.3s ease-in-out;
  }
  @media (min-width: 768px) {
    .contact-container {
      width: 500px;
    }
  }
  
  @media (min-width: 992px) {
    .contact-container {
      width: 700px;
    }
  }
   </style>
  </head>
  <body>
    
    <div class="contact-container">
    <div class="contact-form-container">
        <form class="contact-form">
          <div class="form-group">
            <label for="name">Name:</label>
            <input type="text" name="name" id="name" required>
          </div>
          <div class="form-group">
            <label for="name">Theme:</label>
            <input type="text" name="theme" id="theme" required>
          </div>
          <div class="form-group">
            <label for="message">Message:</label>
            <textarea name="message" id="message" rows="3" required></textarea>
          </div>
          <button class="send_but" type="submit">Send Message</button>
        </form>
       
      </div>
      <input type="text"  class="capthca"/>
      <button class="button"></button>
      <span>11</span>
      <button class="contact-btn">Contact Us</button>
      
    </div>
    <script>
      const contactBtn = document.querySelector('.contact-btn');
      const contactFormContainer = document.querySelector('.contact-form-container');
      
      const input =document.querySelector('.capthca');
      const span =document.querySelector('.text');
      const button =document.querySelector('.button');

      button.addEventListener("click", (e) => {alert(e) 
        if(input.value==11){ alert("done")}})

    contactBtn.addEventListener('click', (e) => {
    contactFormContainer.classList.toggle('active');
    contactBtn.innerHTML = contactFormContainer.classList.contains('active') ? 'Close' : 'Contact Us';
  });
    </script>
  </body>
</html>
