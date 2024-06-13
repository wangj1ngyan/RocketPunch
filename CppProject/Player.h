#ifndef PLAYER_H
#define PLAYER_H

#include <vector>
#include <algorithm>
#include "Card.h"

class Player {
public:
    std::vector<Card*> hand;

    void receive_cards(const std::vector<Card*>& cards);
    void sort_hand();
    std::string display_hand() const;
};

#endif // PLAYER_H
