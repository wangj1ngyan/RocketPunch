local Card = require("Card")

---@class PokerCard : Card
local PokerCard = setmetatable({}, { __index = Card })
PokerCard.__index = PokerCard

---@param suit Suit
---@param rank Rank
---@return PokerCard
function PokerCard:new(suit, rank)
    local instance = Card:new(suit, rank)
    setmetatable(instance, PokerCard)
    return instance
end

function PokerCard:display()
    local suit_to_string = {
        Spade = "S",
        Heart = "H",
        Diamond = "D",
        Club = "C",
        None = ""
    }

    local rank_to_string = {
        A = "A", K = "K", Q = "Q", J = "J", T = "T",
        ["9"] = "9", ["8"] = "8", ["7"] = "7", ["6"] = "6",
        ["5"] = "5", ["4"] = "4", ["3"] = "3", ["2"] = "2"
    }

    return suit_to_string[self.suit] .. rank_to_string[self.rank]
end

return PokerCard
