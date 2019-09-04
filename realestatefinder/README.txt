CPSC 481 Interaction Design Project: ReMacks Real-Estate Listing System
README

Hilmi Abou-Saleh	habousal@ucalgary.ca
Adam Berlak	adam.berlak@ucalgary.ca
Heather Honecker	heather.honecker@ucalgary.ca
Siddharth Kataria	siddharth.kataria@ucalgary.ca
Aaron Kobelsky	aaron.kobelsky@ucalgary.ca

Instructions for using the system:

Our Real-Estate listing system will by default show all 100 listing examples we have created after clicking the search button. You can start customizing the search right at the startpage by clicking
either the rent or buy options and inputting an address if you want your results to be near a landmark. The listings appear in the right bar and you can click on them to get more details. The top bar 
allows the user to filter and customize their search and the map allows you to see the locations of the properties easily.

Implemented Functionality:

Startpage:
> Address bar predicts user input with autocomplete functionality and pairs key places to an address
> We have provided a set of 10 possible search addresses you can input to test the system
	Examples of listings you can search for:
		- "University of Calgary" or "2500 University Dr NW"
		- "Downtown" or "500 Centre St S"
		- "212 Tuscany Way NW"
		- "Robert Thirsk High School" or "8777 Nose Hill Dr NW"
		- "Marion Carson Elementary School" or "5225 Varsity Dr NW"
		- "4820 Northland Dr NW"
		- "SAIT" or "1301 16 Ave NW"
		- "223 10 St NW"
		- "St. Francis High School" or "877 Northmount Dr NW"
		- "7904 43 Ave NW"
		
Homepage:
> We have provided filter options in the top bar for further detailing of the search requirements
	Toggling the Rent and Buy boxes will modify the top bar, disabling apporpriate features. 
	Examples Include:
	- toggling Rent off will disable the 'Max Monthly Rental Price' Slider
	- toggling Rent off will disable the filtering options for inluded Amenities
	
> Our system contains 100 example listings with their own unique attributes, each listing corresponds to a pin located on the map
	- The main window is fully resizable
	- Customizing the search will change the listings displayed in the side bar such that only the appropirate listings are shown
	- Customizing the search will change the pins displayed in the map such that only the unfiltered listings are shown
	- You can customize the search by changing whether you are looking to rent or buy, the max/min price, the property type, the distance to an 
	   landmark, the size of the home, and utilities included if the home is for rent
	- You can add an address or landmark that you want the property to be in close proximity to by entering one of the above searches we hardcoded, 
	   this will display a new pin on the map with a customizable radius, only listings within this radius are shown in the the sidebar
	- Clicking on a pin will push the corresponding listing to the top of the sidebar 
	- The map can be navigated by clicking and dragging
	- You can zoom into the map by scrolling, by using the slider or pressing the (+) and (-) buttons
	- On the sidebar you can scroll through the matching listings
	- On the sidebar you can press the Star button on the top right of the listing to save it, the star will light up to indicate that the listing is saved
	- On the bottom of sidebar there is a view saved listings button that you can press to view any listing you have saved, you can press this same button to return to the general listings
	- Clicking on a listing will open a popup window with more details
	- The map image changes based on the location of the pin
	- Your custom search details can be saved by pressing the save search button, you can enter a name and even provide an email to receive notifications about new listings
	- You can load saved searches by simply pressing the load search button
	
Popups:
	- The gallery in the popup can be navigated to view preview images of the house by pressing the left and right arrows
	- A larger version of the image can be viewed by clicking on the image, and the preview image can be exited by clicking outside of it.
	- Clicking the star in the top right corner of the image will save the listing. This star will be lit up if the listing has already been saved when navigating the sidebar and vise versa
	
Example Walkthrough:

Task: 
Dawn, an RBC employee who uses computer systems for her everyday work tasks, wants to find out if relocating to an RBC branch in Calgary is feasible in terms of rented housing. 
She uses her Windows 8 desktop PC to access a rental search website. She searches for houses or townhouses with at least 2 bedrooms and 2 bathrooms near "7904 43 Ave NW", Calgary. 
The resulting listings are too expensive, so she searches for properties with rent of $2000 or less per month. She finds a townhouse she is interested in, and verifies that it is close to good 
transit routes for work and shopping. She browses through the rest of the listings, and saves 4 potential properties to look over later with her husband.

Steps:
1. Dawn clicks on the Rent button on the startpage
2. She then enters the addres "7904 43 Ave NW" into the searchbar which autocompletes for her
3. She clicks the search button
4. She adjusts the min number of beds and baths by moving the slider in the top bar
5. Dawn navigates through the sidebar with her scroll wheel and clicks on the listings to view popups and get more information
6. She decides the price is too high so she looks at the top left of the top bar and adjusts the Max rental price
7. She continues browsing through listings, occassionally looking at the map to see the distance between the pin and the RBC branch
8. When she finds a listing she likes she presses the star button, either in the popup or while navigating the side bar
9. Dawn saves her search and the next day she loads it up to show her husband

