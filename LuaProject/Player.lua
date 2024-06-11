---@class Player
local Player = {}
Player.__index = Player

---@return Player
function Player:new()
    local instance = {
        hand = {}
    }
    setmetatable(instance, Player)
    return instance
end

function Player:receive_cards(cards)
    for _, card in ipairs(cards) do
        table.insert(self.hand, card)
    end
end

function Player:sort_hand()
    local function card_comparison(x, y)
        if x:isJoker() and y:isJoker() then
            return y:isBigJoker() < x:isBigJoker()  -- Big Joker first
        end
        if x:isJoker() then
            return true  -- Joker before any other card
        end
        if y:isJoker() then
            return false  -- Any other card after Joker
        end
        if x:getSuit() ~= y:getSuit() then
            return x:getSuit() > y:getSuit()  -- Suit order: Spade, Heart, Diamond, Club
        end
        return x:getRank() > y:getRank()  -- Rank in descending order
    end

    table.sort(self.hand, card_comparison)
end

function Player:display_hand()
    local result = ""
    for _, card in ipairs(self.hand) do
        result = result .. card:display() .. " "
    end
    return result
end

return Player
