#!/bin/bash

# this will overwrite existing commit username + email with the given username and email

#how to run:
# 1. put this Skript in the root folder of the Repository
# 2. Open Terminal and cd to the root folder
# 3. make Skript runnable with "chmod u+x change-mail.sh"
# 4. run Skript with "./change-mail.sh"
# 5. check outcome with command "git log"

# define a line as "<email_to_replace> <replace_username> <replace_email>"
declare -a git_users=(
"<email_to_replace> <replace_username> <replace_email>"
"<email_to_replace> <replace_username> <replace_email>"
)
# can be easily extended

overwriteCommits()
{
    wrongEmail=$1
    newName=$2
    newEmail=$3
    printf '\nSearch for email "%s" in every commit + tag, overwrite with "%s" and overwrite username with "%s"\n\n' "$wrongEmail" "$newEmail" "$newName";

    git filter-branch -f --env-filter '
        if [ "$GIT_COMMITTER_EMAIL" = "'"$wrongEmail"'" ]
        then
            export GIT_COMMITTER_NAME="'"$newName"'"
            export GIT_COMMITTER_EMAIL="'"$newEmail"'"
        fi
        if [ "$GIT_AUTHOR_EMAIL" = "'"$wrongEmail"'" ]
        then
            export GIT_AUTHOR_NAME="'"$newName"'"
            export GIT_AUTHOR_EMAIL="'"$newEmail"'"
        fi
    ' --tag-name-filter cat -- --all
}

for user in "${git_users[@]}"; do
    overwriteCommits $user
done
