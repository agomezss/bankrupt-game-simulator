## Bankrupt Game Simulator

Bankrupt simple game implementation and matches simulation

- This project simulates 100 Matches between 4 distinct CPU players and displays the statistcs of winning rates by Player

- A game ends in timeout if the turn count exceed 1000 for that match

## Game Board Setup ##

- There are a simple board that has houses, each house available to buy has a buy value and a rent value 

- This board is setup by a config file called gameConfig.txt

## There are 4 different player CPU AIs implementation ## 

- Careful Player - Will buy an available house only if had eighty coins left after the purchase
- Demanding - Will buy a available house only if the house has a rent value greater than fifty coins
- Impulsive Player - Buy every house that steps if it's not owned by anybody else
- Random Player - There's a fifty percent chance of buyng an available house when steps on one
