### Stored entities

##### Ingredient

Ingredients are products which user makes recipes with.
Ingredients could be *buyable* and *cooked*.
*Buyable* ingredients are used as it is, without any additional preparations. 
*Cooked* ingredients should be prepared by user before using it in recipe.

>  Fields:
>    - Id
>    - Name
>    - Measure

##### Dish

Set of dishes forms *recipe book*.

>  Fields:
>    - Id
>    - Name
>    - **Recipe**:
>      - Portions amount
>      - **Ingredients** list
>      - Steps
>      - Notes
      
##### Menu

User builds daily menu using dishes from *recipe book*.

>  Fields:
>    - List of pairs **Dish** & Portion amount

### Functions

##### Create shopping list

List of pairs **Ingredient** & Measure to buy based on menu.



